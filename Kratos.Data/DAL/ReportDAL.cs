using System.IO;
using System.Linq;
using System.Text;
using FileHelpers;

using Kratos.Data.Model;
using Kratos.Data.Interfaces;

namespace Kratos.Data.DAL
{
  public class ReportDAL : IReportDAL
  {
    private readonly FileHelperEngine<ReportItem> _reportEngine;
    private readonly FileInfo _reportFile;

    public ReportDAL(FileInfo reportFile)
    {
      _reportEngine = new FileHelperEngine<ReportItem>
      {
        HeaderText = ReportItem.HeaderText
      };
      _reportFile = reportFile;
    }

    public void Write(Report report)
    {
      StringBuilder sb = new StringBuilder();

      foreach (var kvp in report.Items)
      {
        if (kvp.Value.Any())
        {
          sb.AppendLine($"{kvp.Key}:");
          sb.AppendLine(_reportEngine.WriteString(kvp.Value));
        }
      }

      foreach (var kvp in report.SkippedItems)
      {
        if (kvp.Value.Any())
        {
          sb.AppendLine($"Skipped {kvp.Key}:");
          sb.AppendLine(_reportEngine.WriteString(kvp.Value));
        }
      }

      foreach (var kvp in report.UnmatchedItems)
      {
        if (kvp.Value.Any())
        {
          sb.AppendLine($"Unmatched {kvp.Key}:");
          sb.AppendLine(_reportEngine.WriteString(kvp.Value));
        }
      }

      // both
      if (report.Duplicates.Any())
      {
        sb.AppendLine("Double:");
        sb.AppendLine(_reportEngine.WriteString(report.Both));
      }

      // duplicates
      if (report.Duplicates.Any())
      {
        sb.AppendLine("Duplicates:");
        sb.AppendLine(_reportEngine.WriteString(report.Duplicates));
      }

 

      // to file
      File.WriteAllText(_reportFile.FullName, sb.ToString());
    }
  }
}