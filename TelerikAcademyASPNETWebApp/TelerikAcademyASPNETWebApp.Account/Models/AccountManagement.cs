using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademyASPNETWebApp.Account.BusinessLayer;
using TelerikAcademyASPNETWebApp.Account.Interfaces;
using TelerikAcademyASPNETWebApp.Database;
using TelerikAcademyASPNETWebApp.Database.Models;

[assembly: InternalsVisibleTo("TelerikAcademyASPNETWebApp")]
namespace TelerikAcademyASPNETWebApp.Account.Models
{
    internal class AccountManagement : IAccountManagement
    {
        private ModelDb _model;

        internal AccountManagement()
        {
            this._model = new ModelDb();
        }

        bool IAccountManagement.UserRegister(RegisterViewModel model)
        {
            using (this._model)
            {
                if (model.Password.Trim().Length > 0 && model.Password.Equals(model.ConfirmPassword))
                {
                    var user = new AcademyUsers()
                    {
                        Email = model.Email,
                        Username = model.Username,
                        Password = model.Password,
                        UserType = model.UserRoles.ToString().Length > 0 && !model.UserRoles.ToString().Equals("-1") ? 
                            int.Parse(model.UserRoles) : 
                            this._model.AcademyUserTypes.FirstOrDefault(m => m.UserType.Equals("Standard")).Id
                    };
                    this._model.AcademyUsers.Add(user);
                    this._model.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        bool IAccountManagement.UserLogin(LoginViewModel model)
        {
            using (this._model)
            {
                if (model.Username.Trim().Length > 0 && model.Password.Trim().Length > 0)
                {
                    var user = this._model.AcademyUsers
                        .Where(m => model.Username.Equals(m.Username) && model.Password.Equals(m.Password))
                        .ToList();
                    return user.Count > 0;
                }
                return false;
            }
        }
    }
}
