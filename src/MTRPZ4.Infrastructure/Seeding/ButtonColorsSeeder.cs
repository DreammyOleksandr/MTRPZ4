using Microsoft.AspNetCore.Hosting.Server;
using MTRPZ4.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.Seeding
{
    public static class ButtonSeeder
    {
        private static Random random = new Random();
         public static List<Color> GetButtonColors() => new List<Color>
        {
            new Color { Id = 1, Pigment = "Red", Count = GetRandomCount(),},
            new Color { Id = 2, Pigment = "Orange", Count = GetRandomCount(),},
            new Color { Id = 3, Pigment = "Blue", Count = GetRandomCount(),}
        };

        public static List<Price> GetButtonPrices() => new List<Price>
        {
            new Price { Id = 1, Value = 12.49M, Count = GetRandomCount(),},
            new Price { Id = 2, Value = 22.78M, Count = GetRandomCount(),},
            new Price { Id = 3, Value = 33.11M, Count = GetRandomCount(),},
        };
        
        public static List<Font> GetButtonFonts() => new List<Font>
        {
            new Font { Id = 1, Type = "Arial", Count = GetRandomCount(),},
            new Font { Id = 2, Type = "Times New Roman", Count = GetRandomCount(),},
            new Font { Id = 3, Type = "Comic Sans", Count = GetRandomCount(),}
        };
        private static int GetRandomCount() => random.Next(10, 30);


    }
}
