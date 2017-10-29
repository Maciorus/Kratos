using System.Collections.Generic;

namespace Kratos.Utils
{
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