using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Data.Interfaces
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
