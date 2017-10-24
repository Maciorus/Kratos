using System.Collections.Generic;
using Kratos.Business.Extensions;
using Kratos.Business.Model;
using Report = Kratos.Business.Model.Report;

namespace Kratos.Business.Logic.Factories
{
    public class ReportFactory
    {
        public static Report Create(
            List<Detail> detail,
            Dictionary<ulong, Document> documents,
            Dictionary<ulong, List<Document>> duplicates,
            Dictionary<ulong, List<Document>> both)
        {
            int itemId = 1;

            var reportItems = new Report(detail.Count);

            DocumentGroupType group = DocumentGroupType.Unknown;

            for (int index = 0; index < detail.Count; index++)
            {
                AssignGroup(ref itemId, ref group, detail[index].GroupCell);

                if (null != detail[index].DocumentId)
                {
                    ulong documentId = (ulong) detail[index].DocumentId;
                    if (documents.ContainsKey(documentId))
                    {
                        if (!documents[documentId].Type.ExcludeFromGroup(group, detail[index].TRS))
                        {
                            reportItems.Items[group].Add(
                                ReportItemFactory.Create(
                                    detail[index],
                                    documents[documentId],
                                    itemId++));
                        }
                        else
                        {
                            reportItems.SkippedItems[group].Add(
                                ReportItemFactory.Create(
                                    detail[index],
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
                                ReportItemFactory.Create(
                                    detail[index],
                                    dup,
                                    itemId));
                        }
                    }
                    else if (both.ContainsKey(documentId))
                    {
                        itemId++;

                        foreach (var multi in both[documentId])
                        {
                            reportItems.Both.Add(
                                ReportItemFactory.Create(
                                    detail[index],
                                    multi,
                                    itemId));
                        }
                    }
                    else
                    {
                        reportItems.UnmatchedItems[group].Add(ReportItemFactory.Create(
                            detail[index],
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
