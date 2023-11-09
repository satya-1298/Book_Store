using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusiness bookBusiness;
        public BooksController(IBookBusiness book)
        {
            this.bookBusiness = book;
        }
        [HttpPost]
        [Route("Create_Book")]
        public IActionResult BookCreation(CreateBookModel createBook)
        {
            string result = User.FindFirst(ClaimTypes.Role).Value.ToString();
            string role = "Admin";
            if(result==role)
            {
                var val = bookBusiness.Creation(createBook);
                if(val!=null)
                {

                    return this.Ok(new { success = true, message = "Book created Successfully", data = val });
                }
                
                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
                
            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "Only Admin can create books" });
            }

        }
        [Authorize]
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(CreateBookModel updateBook,int id)
        {
            string result = User.FindFirst(ClaimTypes.Role).Value.ToString();
            string role = "Admin";
            if (result == role)
            {
                var val = bookBusiness.Update(updateBook,id);
                if (val != null)
                {

                    return this.Ok(new { success = true, message = "Book Updated Successfully", data = val });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });

            }
            else
            {
                return this.BadRequest(new { sucess = false, message = "Only Admin can Update books" });
            }

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult AllBooks()
        {
           
                var val = bookBusiness.AllBooks();
                if (val != null)
                {
                    return this.Ok(new { success = true, message = " Successfully", data = val });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
         

        }
       
        [HttpGet]
        [Route("GetById")]
        public IActionResult BooksById(int Id)
        {
           
                var val = bookBusiness.RetrievbyID(Id);
                if (val != null)
                {
                    return this.Ok(new { success = true, message = " Successfully", data = val });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
        
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int Id)
        {
            string result = User.FindFirst(ClaimTypes.Role).Value.ToString();
            if (result == "Admin")
            {
                var val = bookBusiness.Delete(Id);
                if (val != null)
                {
                    return this.Ok(new { success = true, message = " deleted Successfully" });
                }

                return this.BadRequest(new { sucess = false, message = "Unsuccesfull" });
            }
            return this.BadRequest(new { sucess = false, message="Admin can only delete ",data = result });

        }

    }
}
