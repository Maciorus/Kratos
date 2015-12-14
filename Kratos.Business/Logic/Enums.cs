using System;

namespace Kratos.Business.Logic
{
  public enum DocumentType
  {
    Unknown = 0,

    Sale = 1,

    Purchase = 2,

    [InputExclude]
    [OutputExclude]
    Suspicious = 10,
    [OutputExclude]
    Adjustement = 12,
    [InputExclude]
    [OutputExclude]
    ClosingAccural = 16,
    [InputExclude]
    [OutputExclude]
    OpeningAccrual = 19
  }

  public enum DocumentGroupType
  {
    Unknown = 0,
    Output = 1,
    Input = 2
  }

  public class OutputExcludeAttribute : Attribute
  {
  }

  public class InputExcludeAttribute : Attribute
  {
  }
}

