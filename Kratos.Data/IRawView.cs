namespace Kratos.Data
{
  public interface IRawView
  {
    string Reference { get; }

    string Currency { get; }

    string Amount { get; }

    string PoundAmount { get; }

    string Type { get; }
  }
}
