using System;
using System.Linq;
using Kratos.Business.Logic;

namespace Kratos.Business.Extensions
{
  public static class DocumentTypeExtensions
  {
    private static readonly string[] EsaOrEse = { "ESA", "ESE" };
    
    public static DocumentType ParseType(this string documentNumber, DocumentType defaultType)
    {
      var code = documentNumber.Substring(0, 2);

      switch (code)
      {
        case "10":
          return DocumentType.Suspicious;
        case "12":
          return DocumentType.Adjustement;
        case "16":
          return DocumentType.ClosingAccural;
        case "19":
          return DocumentType.OpeningAccrual;
        default:
          return defaultType;
      }
    }

    public static bool ExcludeFromGroup(this DocumentType documentType, DocumentGroupType @group, string tsr)
    {
      switch (group)
      {
        case DocumentGroupType.Output:
          var g = documentType.GetType();
          var h = g.GetCustomAttributes(typeof(OutputExcludeAttribute), false);
          return EsaOrEse.Contains(tsr) || h.Any();
        case DocumentGroupType.Input:
          return  documentType.GetType().GetCustomAttributes(typeof(InputExcludeAttribute), false).Any();
        default:
          throw new ArgumentOutOfRangeException(nameof(@group), @group, null);
      }
    }
  }
}
