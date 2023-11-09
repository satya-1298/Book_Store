using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Interface;
using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBusiness:IUserBusiness
    {
        private readonly IUserRepo userRepo;
        public UserBusiness(IUserRepo user)
        {
            this.userRepo = user;
        }
        public Users UserReg(UserRegister userRegister, string role)
        {
            try
            {
                return userRepo.UserReg(userRegister,role);
            }
            catch 
            {
                 return null;
            }
        }
        public string ULogin(UserLogin userLogin)
        {
            try
            {
                return userRepo.ULogin(userLogin);
            }
            catch 
            {
                return null;
            }
        }
        public string ForgotPassword(string Email)
        {
            try
            {
                return userRepo.ForgotPassword(Email);
            }
            catch
            {
                return null;
            }
        }
        public bool ResetPassword(string email, ResetPasswordModel resetPassword)
        {
            try
            {
                return userRepo.ResetPassword(email,resetPassword);
            }
            catch
            {
                return false;
            }
        }
    }
}
