using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSystem.Domain.DTOs
{
    public class RawInvoiceDetailDto
    {
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
        public long InvoiceHeaderID { get; set; }
    }
}
