using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademyASPNETWebApp.Account.BusinessLayer;

[assembly: InternalsVisibleTo("TelerikAcademyASPNETWebApp")]
namespace TelerikAcademyASPNETWebApp.Account.Interfaces
{
    internal interface IAccountManagement
    {
        bool UserRegister(RegisterViewModel model);
        bool UserLogin(LoginViewModel model);
    }
}
