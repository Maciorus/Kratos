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

    public static Tuple<Dictionary<TKey, TValue>, Dictionary<TKey, List<TValue>>> GetDuplicateAndMerge<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
    {
      var all = new Dictionary<TKey, List<TValue>>();

      foreach (var dictionary in dictionaries)
      {
        foreach (var key in dictionary.Keys)
        {
          if (!all.ContainsKey(key))
          {
            all.Add(key, new List<TValue>());
          }

          all[key].Add(dictionary[key]);
        }
      }

      var merge = all.Where(x => x.Value.Count == 1).ToDictionary(pair => pair.Key, pair => pair.Value.First());

      var duplicate = all.Where(x => x.Value.Count > 1).ToDictionary(pair => pair.Key, pair => pair.Value); 

      return new Tuple<Dictionary<TKey, TValue>, Dictionary<TKey, List<TValue>>>(merge, duplicate);
    }
  }
}
