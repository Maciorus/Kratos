using System.Collections.Generic;
using Kratos.Business.Extensions;
using Kratos.Business.Logic;
using Kratos.Business.Model;
using Kratos.Data.Model;

namespace Kratos.Data.Factories
{
  public class PayablesFactory
  {
    public const string Vendor = "Vendor";

    public static Payables Create(List<RawPayable> rawPayable)
    {
      var payables = new Payables();

      for (int index = 0; index < rawPayable.Count; index++)
      {
        if (rawPayable[index].Col1.Contains(Vendor) && rawPayable[index].Col5 != "*")
        {
          var vendor = new Company();
          var j = index;
          var vendorId = ulong.Parse(rawPayable[index].Col5.Trim());

          vendor.CompanyId = vendorId;
          vendor.Code = int.Parse(rawPayable[++j].Col5.Trim());
          j = j + 2;

          vendor.Name = rawPayable[j].Col5.Trim();

          for (; j < rawPayable.Count; j++)
          {
            if (rawPayable[j].Col1.Contains(Vendor))
            {
              index = j - 1;
              break;
            }

            ulong documentId;
            if (ulong.TryParse(rawPayable[j].Col5, out documentId))
            {
              var type = rawPayable[j].Type.ParseType(DocumentType.Purchase);

              var document = DocumentFactory.Create(rawPayable[j], documentId, vendor, type);

              if(payables.Duplicates.ContainsKey(documentId))
              {
                payables.Duplicates[documentId].Add(document);
              }
              else if(payables.Documents.ContainsKey(documentId))
              {
                payables.Duplicates.Add(
                  documentId, 
                  new List<Document>() {
                    payables.Documents[documentId],
                    document });

                payables.Documents.Remove(documentId);
              }
              else 
              {
                payables.Documents.Add(documentId, document);
              }
            }

            index = j + 1;
          }

          payables.Vendors.Add(vendor);
        }
      }

      return payables;
    }
  }
}
