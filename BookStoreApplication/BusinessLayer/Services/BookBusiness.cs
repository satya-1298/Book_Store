using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Interface;
using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBusiness:IBookBusiness
    {
        private readonly IBookRepo bookBusiness;
        public BookBusiness(IBookRepo book)
        {
            this.bookBusiness = book;
        }
        public Books Creation(CreateBookModel createBookModel)
        {
            try
            {
                return bookBusiness.Creation(createBookModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Books Update(CreateBookModel createBookModel, int id)
        {
            try
            {
                return bookBusiness.Update(createBookModel, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Books Delete(int id)
        {
            try
            {
                return bookBusiness.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Books RetrievbyID(int id)
        {
            try
            {
                return bookBusiness.RetrievbyID(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Books> AllBooks()
        {
            try
            {
                return bookBusiness.AllBooks();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
