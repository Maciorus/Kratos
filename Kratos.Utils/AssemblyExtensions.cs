using System;
using System.Text;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;

namespace Kratos.Utils
{
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
}