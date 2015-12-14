using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kratos.Business.Logic;

namespace Kratos.Business.Model
{
  public class Document
  {
    public string Reference { get; set; }

    public Company Company { get; set; }

    public ulong Number { get; set; }

    public string Currency { get; set; }

    public decimal Amount { get; set; }

    public decimal PoundAmount { get; set; }

    public DocumentType Type { get; set; }
  }
}
