using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Data.Model
{
  public class Report
  {

    public Report()
    {
      Items = new Dictionary<string, List<ReportItem>>();
      SkippedItems = new Dictionary<string, List<ReportItem>>();
      UnmatchedItems = new Dictionary<string, List<ReportItem>>();
    }

    public Dictionary<string, List<ReportItem>> Items { get; set; }

    public Dictionary<string, List<ReportItem>> SkippedItems { get; set; }

    public Dictionary<string, List<ReportItem>> UnmatchedItems { get; set; }

    public List<ReportItem> Duplicates { get; set; } = new List<ReportItem>();

    public List<ReportItem> Both { get; set; } = new List<ReportItem>();
  }
}




