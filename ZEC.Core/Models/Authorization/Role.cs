using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEC.Core.Models.Authorization
{
    public enum Role : int
    {
        Admin = 1,
        ContentManager = 2,
        Moderator = 3,
        Vendor = 4,
        Customer = 5
    }
}
