using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.CoreDomain.Entities
{
    public class User : IdentityUser
    {
        public bool IfCompletedTest { get; set; }
       
    }
}
