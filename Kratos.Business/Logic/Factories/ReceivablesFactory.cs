using System.Collections.Generic;
using Kratos.Business.Extensions;
using Kratos.Business.Model;
using Kratos.Data.Model;

namespace Kratos.Business.Logic.Factories
{
  public class ReceivablesFactory
  {
    public const string Customer = "Customer";

    public static Receivables Create(List<RawReceivable> rawReceivables)
    {
      var receivables = new Receivables();

      for (int index = 0; index < rawReceivables.Count; index++)
      {
        if (rawReceivables[index].Col1.Contains(Customer) && rawReceivables[index].Col5 != "*")
        {
          var customer = new Company();
          var j = index;
          var customerId = ulong.Parse(rawReceivables[index].Col5.Trim());

          customer.CompanyId = customerId;
          customer.Code = int.Parse(rawReceivables[++j].Col5.Trim());
          j = j + 2;

          customer.Name = rawReceivables[j].Col5.Trim();

          for (; j < rawReceivables.Count; j++)
          {
            if (rawReceivables[j].Col1.Contains(Customer))
            {
              index = j - 1;
              break;
            }

            ulong documentId;
            if (ulong.TryParse(rawReceivables[j].Col6, out documentId))
            {
              var type = rawReceivables[j].Type.ParseType(DocumentType.Sale);

              var document = DocumentFactory.Create(rawReceivables[j], documentId, customer, type);

              if (receivables.Duplicates.ContainsKey(documentId))
              {
                receivables.Duplicates[documentId].Add(document);
              }
              else if (receivables.Documents.ContainsKey(documentId))
              {
                receivables.Duplicates.Add(
                  documentId,
                  new List<Document>() {
                    receivables.Documents[documentId],
                    document });

                receivables.Documents.Remove(documentId);
              }
              else
              {
                receivables.Documents.Add(documentId, document);
              }
            }

            index = j + 1;
          }

          receivables.Customers.Add(customer);
        }
      }

      return receivables;
    }
  }
}
