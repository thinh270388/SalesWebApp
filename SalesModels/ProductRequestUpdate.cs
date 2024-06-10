using SalesModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModels
{
    public class ProductRequestUpdate
    {
        public string Name { get; set; } = null!;
        public double InputPrice { get; set; }
        public double OutputPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = null!;
        public StatusProduct Status { get; set; }
        public Guid CategoryId { get; set; }
    }
}
