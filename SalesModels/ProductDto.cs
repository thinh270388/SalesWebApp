using SalesModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModels
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double InputPrice { get; set; }
        public double OutputPrice { get; set; }
        public int Quantity { get; set; }
        public StatusProduct Status { get; set; }
        public string Description { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
