using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Business.Extensions
{
  public static class DictionaryExtensions
  {
    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
    {
      return dictionaries.SelectMany(dict => dict)
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

    }
  }
}
