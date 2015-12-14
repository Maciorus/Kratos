using System;
using FileHelpers;
using Kratos.Data.Converters;

namespace Kratos.Data.Model
{
  [DelimitedRecord(",")]
  public class ReportItem
  {
    public static string HeaderText = @"Id,Company,Date,Reference,DocumentNumber,Currency,Amount,Net,VAT,Total";

    [FieldQuoted()]
    public int ItemId;
    // Supplier/Customer 
    [FieldQuoted()]
    public string Company;
    [FieldQuoted()]
    [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
    public DateTime Date;
    [FieldQuoted()]
    public string Reference;
    [FieldQuoted()]
    public ulong DocumentNumber;
    [FieldQuoted()]
    public string Currency;
    [FieldQuoted()]
    [FieldConverter(typeof(MoneyConverter))]
    public decimal? Amount;
    [FieldQuoted()]
    [FieldConverter(typeof(MoneyConverter))]
    public decimal Net;
    [FieldQuoted()]
    [FieldConverter(typeof(MoneyConverter))]
    public decimal VAT;
    [FieldQuoted()]
    [FieldConverter(typeof(MoneyConverter))]
    public decimal Total;
  }

  ////[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
  ////public class FieldTitleAttribute : Attribute
  ////{
  ////  public FieldTitleAttribute(string name)
  ////  {
  ////    if (name == null) throw new ArgumentNullException("name");
  ////    Name = name;
  ////  }

  ////  public string Name { get; private set; }
  ////}

  

}
