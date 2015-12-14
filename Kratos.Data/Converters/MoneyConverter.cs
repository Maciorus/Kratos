using System;
using System.Globalization;
using FileHelpers;

namespace Kratos.Data.Converters
{
  public class MoneyConverter : ConverterBase
  {
    

    public override object StringToField(string from)
    {
      return from;
    }

    public override string FieldToString(object fieldValue)
    {
      if (fieldValue == null)
      {
        return string.Empty;
      }

      var value = (decimal)fieldValue;
      if (value == 0)
      {
        return "-";
      }

      if (value < 0)
      {
        return $"({FormatDecimal(Math.Abs(value))})";
      }

      return FormatDecimal(value);
    }

    private string FormatDecimal(decimal value)
    {
      return value.ToString("N2");
    }
  }
}