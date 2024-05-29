using MTRPZ4.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Application.DTO
{
    public class CardDTO
    {
        public CardElementDTO Color { get; set; }
        public CardElementDTO Font { get; set; }
        public CardElementDTO Price { get; set; }
    }
}
