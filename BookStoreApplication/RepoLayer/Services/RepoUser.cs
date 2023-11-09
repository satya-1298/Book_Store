using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Interface;
using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepoLayer.Services
{
    public class RepoUser:IUserRepo
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IConfiguration configuration;
        public RepoUser(BookStoreDBContext bookStoreDB ,IConfiguration configuration)
        {
           this. _dbContext = bookStoreDB; 
            this.configuration = configuration;
        }
        public Users UserReg(UserRegister userRegister,string role)
        {
            try
            {
                Users users = new Users();
                var result = _dbContext.Users.FirstOrDefault(x => x.Email == userRegister.Email);
                if (result != null)
                {
                    return null;
                }
                else
                {
                    users.Username = userRegister.Username;
                    users.Password = userRegister.Password;
                    users.Email = userRegister.Email;
                    users.Role =role;
                    _dbContext.Users.Add(users);
                    _dbContext.SaveChanges();
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error While addding data");
            }
        }
        // JWT TOKEN GENERATE:-
        public string GenerateToken(string Email, long UserId,string Role)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(configuration["JwtConfig:key"]);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", UserId.ToString()),
                    new Claim(ClaimTypes.Email, Email),
                    new Claim(ClaimTypes.Role,Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(130),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public string ULogin(UserLogin userLogin)
        {
            try
            {
                var result = _dbContext.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
                if(result != null)
                {
                    var jwtToken = GenerateToken(result.Email, result.UserId,result.Role);
                    return jwtToken;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string ForgotPassword(string Email)
        {
            try
            {
                var result = _dbContext.Users.FirstOrDefault(u => u.Email == Email);
                if (result != null)
                {
                    var Token = GenerateToken(result.Email, result.UserId, result.Role);

                    return Token;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ResetPassword(string email, ResetPasswordModel resetPassword)
        {
            try
            {
                if (resetPassword.Password.Equals(resetPassword.confirmPassword))
                {
                    var user = _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = resetPassword.confirmPassword;

                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
