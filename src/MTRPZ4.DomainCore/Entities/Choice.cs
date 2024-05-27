using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.CoreDomain.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public int? ColorId { get; set; }
        public int? PriceId { get; set; }
        public int Count { get; set; }

        public Price? Price { get; set; }
        public Color? Color { get; set; }

    }
}
