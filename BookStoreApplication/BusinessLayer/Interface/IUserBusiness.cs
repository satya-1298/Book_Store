using CommonLayer.Model;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public Users UserReg(UserRegister userRegister, string role);
        public string ULogin(UserLogin userLogin);
        public string ForgotPassword(string Email);
        public bool ResetPassword(string email, ResetPasswordModel resetPassword);

    }
}
