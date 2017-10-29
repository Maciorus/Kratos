using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Kratos.Utils
{
  public class AssemblyLoader : IAssemblyLoader
  {
    private readonly Assembly _executingAssembly;
    private readonly List<string> _assemblyQualifiers;

    public AssemblyLoader(Assembly executingAssembly, List<string> assemblyQualifiers)
    {
      _executingAssembly = executingAssembly;
      _assemblyQualifiers = assemblyQualifiers;
    }

    public IEnumerable<Assembly> GetAssemblies()
    {
      var assemblyPath = Path.GetDirectoryName(_executingAssembly.Location);

      if (assemblyPath == null)
      {
        throw new ArgumentNullException("Cannot find executing assembly directory");
      }

      var assemblies = Directory
        .EnumerateFiles(assemblyPath, "*.*", SearchOption.AllDirectories)
        .Where(file => file.EndsWith(".dll"))
        .Select(file => file.ToAssemblyName())
        .Where(assemblyName => _assemblyQualifiers.Any(x => assemblyName.FullName.StartsWith(x)))
        .Select(Assembly.Load)
        .ToList();

      assemblies.Add(_executingAssembly);

      return assemblies;
    }
  }
}