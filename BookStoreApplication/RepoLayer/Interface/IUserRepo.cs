using CommonLayer.Model;
using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public Users UserReg(UserRegister userRegister, string role);
        public string ULogin(UserLogin userLogin);
        public string ForgotPassword(string Email);
        public bool ResetPassword(string email, ResetPasswordModel resetPassword);
    }
}
