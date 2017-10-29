using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;

namespace Kratos.Utils
{
  public class WindsorInstallerLoader
  {
    public IWindsorInstaller[] GetInstallers(IAssemblyLoader assemblyProvider)
    {
      var installers = new List<IWindsorInstaller>();

      var assemblies = assemblyProvider.GetAssemblies();

      foreach (var assembly in assemblies)
      {
        var types = assembly.GetTypes().Where(t => 
          t.GetInterfaces()
            .Contains(typeof(IWindsorInstaller)) 
          && t.GetConstructor(Type.EmptyTypes) != null);

        foreach (var type in types)
        {
          installers.Add(Activator.CreateInstance(type) as IWindsorInstaller);
        }
      }

      return installers.ToArray();
    }
  }
}