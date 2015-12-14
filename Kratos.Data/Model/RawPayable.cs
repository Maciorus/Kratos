using FileHelpers;
using Kratos.Data.Interfaces;

namespace Kratos.Data.Model
{
  [DelimitedRecord(",")]
  public class RawPayable : IRawView
  {
    public string Col1;
    public string Col2;
    public string Col3;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col4;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col5;
    public string Col6;
    public string Col7;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col8;
    public string Col9;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col10;
    [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.NotAllow)]
    public string Col11;

    public string Reference => Col4;

    public string Currency => Col7;

    public string Amount => Col8;

    public string PoundAmount => Col10;

    public string Type => Col5;
  }
}

