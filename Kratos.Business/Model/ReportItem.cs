using System;

namespace Kratos.Business.Model
{
  public class ReportItem
  {
    public int ItemId { get; set; }
 
    // Supplier/Customer 
    public string Company { get; set; }

    public DateTime Date   { get; set; }

    public string Reference { get; set; }

    public string Trs { get; set; }

    public ulong DocumentNumber { get; set; }

    public string Currency { get; set; }

    public decimal? Amount { get; set; }

    public decimal Net { get; set; }

    public decimal VAT { get; set; }

    public decimal Total { get; set; }
  }
}
