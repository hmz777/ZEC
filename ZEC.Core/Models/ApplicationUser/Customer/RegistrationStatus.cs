using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEC.Core.Models.ApplicationUser.Customer
{
    public enum RegistrationStatus : int
    {
        Standard = 1,
        EmailVerification = 2,
        AdminApproval = 3,
        Disabled = 4
    }
}
