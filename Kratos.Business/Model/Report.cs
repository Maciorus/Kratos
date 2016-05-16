using Kratos.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kratos.Business.Model
{
  public class Report
  {
    public Report(int count)
    {
      Items = new Dictionary<DocumentGroupType, List<ReportItem>>(count);
      SkippedItems = new Dictionary<DocumentGroupType, List<ReportItem>>();
      UnmatchedItems = new Dictionary<DocumentGroupType, List<ReportItem>>();

      var groups = Enum.GetValues(typeof(DocumentGroupType)).Cast<DocumentGroupType>();

      foreach (var group in groups)
      {
        if (group != DocumentGroupType.Unknown)
        {
          Items.Add(group, new List<ReportItem>());
          SkippedItems.Add(group, new List<ReportItem>());
          UnmatchedItems.Add(group, new List<ReportItem>());
        }
      }
    }

    public Dictionary<DocumentGroupType, List<ReportItem>> Items { get; set; }

    public Dictionary<DocumentGroupType, List<ReportItem>> SkippedItems { get; set; }

    public Dictionary<DocumentGroupType, List<ReportItem>> UnmatchedItems { get; set; }

    public List<ReportItem> Duplicates { get; set; } = new List<ReportItem>();

    public List<ReportItem> Both { get; set; } = new List<ReportItem>();
  }
}
