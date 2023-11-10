using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Models;
using System.Linq;
using System.Security.Claims;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        public UserController(IUserBusiness business)
        {
            this.userBusiness = business;
        }

        /// <summary>
        /// Registeration of User for only Customers
        /// </summary>
        /// <param name="userRegister"></param>
        /// <returns>result</returns>
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult Register(UserRegister userRegister)
        {
            string role = "Customer";
            var result = userBusiness.UserReg(userRegister,role);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "User Registered", data = result });
            }
            else
            {
                return this.BadRequest(new {sucess=false,message="Unsuccesfull"});
            }
        }

        /// <summary>
        /// Admin Registeration in which we used
        /// Authorization  for Admin register which is valide by default Admin
        /// when role is equal to admin the user will register
        /// </summary>
        /// <param name="register"></param>
        /// <returns>val</returns>
        [Authorize]
        [HttpPost]
        [Route("AdminRegister")]
        public IActionResult AdminReg(UserRegister register)
        {
            int result = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            if(result==1)
            {
                string role = "Admin";
                var val=userBusiness.UserReg(register, role);
                if(val!=null)
                {
                    return this.Ok(new { success = true, message = "User Registered", data = val });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
                }
            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "User not exist" });
            }
        }

        /// <summary>
        /// Here Login for Admin and Customer is same ,
        /// by using claims it will differ the customer and admin
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>result</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            var result=userBusiness.ULogin(userLogin);
            if (result != null)
            {
                return this.Ok(new {success=true, message="Login Successfully",data=result});
            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }
        }
        /// <summary>
        /// Generating Token for ForgetPassword
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>result</returns>
        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult Password(string Email)
        {

            var result=userBusiness.ForgotPassword(Email);
            if (result != null)
            {

                return this.Ok(new { success = true,  data = result });
            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }

        }

        /// <summary>
        /// Reseting the password with authorization
        /// </summary>
        /// <param name="model"></param>
        /// <returns>result</returns>
        [Authorize]
        [HttpPut]
        [Route("Reset")]
        public IActionResult ResetPass(ResetPasswordModel model)
        {
            string email=User.FindFirst(ClaimTypes.Email).Value.ToString();
            var result=userBusiness.ResetPassword(email,model);
            if (result != null)
            {

                return this.Ok(new { success = true, message = "password change Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }
        }
    }
}
