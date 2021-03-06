﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kratos.Business.Model
{
  public class Receivables
  {
    public List<Company> Customers { get; set; } = new List<Company>();

    public Dictionary<ulong, Document> Documents { get; set; } = new Dictionary<ulong, Document>();

    public Dictionary<ulong, List<Document>> Duplicates { get; set; } = new Dictionary<ulong, List<Document>>();
  }
}
