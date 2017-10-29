using System.Collections.Generic;
using System.Reflection;

namespace Kratos.Utils
{
  public interface IAssemblyLoader
  {
    IEnumerable<Assembly> GetAssemblies();
  }
}