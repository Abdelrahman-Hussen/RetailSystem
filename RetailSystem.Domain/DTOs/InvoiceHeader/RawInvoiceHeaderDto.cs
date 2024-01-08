using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSystem.Domain.DTOs
{
    public class RawInvoiceHeaderDto
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Invoicedate { get; set; }
        public double TotalPrice { get; set; }
    }
}
