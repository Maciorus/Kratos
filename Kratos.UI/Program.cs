using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Kratos.Business.Interfaces;
using Kratos.Business.Services;

namespace Kratos.UI
{
  class Program
  {
    static void Main(string[] args)
    {
      var container = new WindsorContainer();

      var installers = GetInstallers(GetAssemblies().ToList());

      container.Install(installers);

      var detailsRepository = container.Resolve<IDetailsRepository>();
      var payablesRepository = container.Resolve<IPayablesRepository>();
      var receivevablesRepository = container.Resolve<IReceivevablesRepository>();
      var reportRepository = container.Resolve<IReportRepository>();

      var rc = new ReportService(payablesRepository, receivevablesRepository, detailsRepository, reportRepository);
      rc.GenerateReport();
    }

    public static IEnumerable<Assembly> GetAssemblies()
    {
      var trackingList = new List<string>();

      var executingAssembly = Assembly.GetExecutingAssembly();

      var stack = new Stack<AssemblyName>(new List<AssemblyName>() { executingAssembly.GetName() });
      
      string path = Path.GetDirectoryName(executingAssembly.Location);
      
      var files = Directory
        .EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
        .Where(file=> file.EndsWith(".dll"))
        .Select(file => file.ToAssemblyName())
        .Where(assemblyName => assemblyName.FullName.StartsWith("Kratos"))
        .ToList();
      
      foreach (var assemblyName in files)
      {
        stack.Push(assemblyName);
      }
      
      do
      {
        var assemblyName = stack.Pop();

        if (!trackingList.Contains(assemblyName.FullName))
        {
          var assembly = Assembly.Load(assemblyName);
          trackingList.Add(assembly.FullName);
          yield return assembly;

          foreach (var reference in assembly.GetReferencedAssemblies())
            if (!trackingList.Contains(reference.FullName))
            {
              var referencedAssembly = Assembly.Load(reference);

              stack.Push(referencedAssembly.GetName());

              trackingList.Add(reference.FullName);
            }
        }
      }
      while (stack.Any());

    }

 

    public static IWindsorInstaller[] GetInstallers(IEnumerable<Assembly> assemblies)
    {
      var installers = new List<IWindsorInstaller>();

      foreach (var assembly in assemblies)
      {
        var types = assembly.GetTypes().Where(t => t
          .GetInterfaces()
          .Contains(
              typeof(IWindsorInstaller)) && 
              t.GetConstructor(Type.EmptyTypes) != null);

        foreach (var type in types)
        {
          installers.Add(Activator.CreateInstance(type) as IWindsorInstaller);
        }
      }

      return installers.ToArray();
    }
  }

  public static class AssemblyExtensions
  {
    //TODO: TESTS
    public static AssemblyName ToAssemblyName(this string fullName)
    {
      if (fullName.IsNullOrEmpty())
      {
        throw new ArgumentNullException("fullname");
      }

      if (!fullName.Contains('\\'))
      {
        throw new ArgumentNullException("fullname does not contain \\");
      }

      var pathSplit = fullName.Split('\\');

      var assemblyFileName = pathSplit.Last();

      if (!assemblyFileName.Contains('.'))
      {
        throw new ArgumentNullException("assemblyFileName does not contain .");
      }
      
      var assemblyName = assemblyFileName.Substring(0, assemblyFileName.LastIndexOf('.'));

      return new AssemblyName(assemblyName);
    }
  }

  public static class StringExtensions
  {
    //TODO: TESTS
    public static IEnumerable<string> TrimLast(this string[] @string)
    {
      for (var i = 0; i < @string.Length - 1; i++)
      {
        yield return @string[i];
      }
    }
  }
}

