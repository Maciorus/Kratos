using System.Collections.Generic;
using Kratos.Business.Extensions;
using Kratos.Business.Model;
using Kratos.Data.Model;
using Report = Kratos.Business.Model.Report;

namespace Kratos.Business.Logic.Factories
{
  public class ReportItemsFactory
  {
    public static Report Create(
      List<RawDetail> rawDetails, 
      Dictionary<ulong, Document> documents,
      Dictionary<ulong, List<Document>> duplicates)
    {
      int itemId = 1;

      var reportItems = new Report(rawDetails.Count);

      DocumentGroupType group = DocumentGroupType.Unknown;

      for (int index = 0; index < rawDetails.Count; index++)
      {
        AssignGroup(ref itemId, ref group, rawDetails[index].Col3);
        
        ulong documentId;

        if(ulong.TryParse(rawDetails[index].Col14, out documentId))
        {
          if (documents.ContainsKey(documentId))
          {
            if (!documents[documentId].Type.ExcludeFromGroup(group, rawDetails[index].Col20))
            {
              reportItems.Items[group].Add(
                ItemFactory.Create(
                  rawDetails[index],
                  documents[documentId],
                  itemId++));
            }
            else
            {
              reportItems.SkippedItems[group].Add(
                ItemFactory.Create(
                  rawDetails[index],
                  documents[documentId],
                  itemId++));
            }
          }
          else if (duplicates.ContainsKey(documentId))
          {
            itemId++;

            foreach (var dup in duplicates[documentId])
            {
              reportItems.Duplicates.Add(
                ItemFactory.Create(
                    rawDetails[index],
                    dup,
                    itemId));
            }
          }
          else
          {
            reportItems.UnmatchedItems[group].Add(ItemFactory.Create(
                  rawDetails[index],
                  documentId,
                  itemId++));
          }
        }
      }

      return reportItems;
    }

    private static void AssignGroup(ref int itemId, ref DocumentGroupType group, string groupCell)
    {
      if (groupCell.Contains("Output tax: Line items"))
      {
        group = DocumentGroupType.Output;

        itemId = 1;
      }

      if (groupCell.Contains("Input tax: Line items"))
      {
        group = DocumentGroupType.Input;

        itemId = 1;
      }
    }
  }
}
