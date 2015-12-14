using FileHelpers;
using Kratos.Data.Interfaces;

namespace Kratos.Data.Model
{
  [DelimitedRecord(",")]
  public class RawReceivable : IRawView
  {
    public string Col1;
    public string Col2;
    public string Col3;
    public string Col4;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col5;
    public string Col6;
    public string Col7;
    public string Col8;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col9;
    public string Col10;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col11;
    public string Col12;
    public string Col13;

    public string Reference => Col4;

    public string Currency => Col10;

    public string Amount => Col9;

    public string PoundAmount => Col11;

    public string Type => Col6;
  }
}
