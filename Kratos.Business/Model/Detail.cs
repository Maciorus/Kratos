using System;

namespace Kratos.Business.Model
{
    public class Detail
    {
        public ulong ?DocumentId { get; set; }

        public string GroupCell { get; set; }

        public string TRS { get; set; }
        public string Reference { get; set; }
        public decimal Net { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
