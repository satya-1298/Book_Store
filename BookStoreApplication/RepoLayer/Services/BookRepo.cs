using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Services
{
    public class BookRepo:IBookRepo
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IConfiguration configuration;
        public BookRepo(BookStoreDBContext bookStoreDB,IConfiguration configuration)
        {
            this._dbContext = bookStoreDB;
            this.configuration = configuration;
        }
        public Books Creation(CreateBookModel createBookModel)
        {
            try
            {
                Books books = new Books();
                books.Title = createBookModel.Title;
                books.Description = createBookModel.Description;
                books.Author = createBookModel.Author;
                books.Isbn = createBookModel.Isbn;
                books.Price = createBookModel.Price;
                books.PageNo = createBookModel.PageNo;
                books.Images = createBookModel.Images;
                _dbContext.Books.Add(books);
                _dbContext.SaveChanges();
                return books;

            }
            catch
            {
                return null;
            }
        }
        public Books Update(CreateBookModel createBookModel,int id)
        {
            try
            {
                var result = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
                if(result != null)
                {
                  
                    result.Title = createBookModel.Title;
                    result.Author = createBookModel.Author;
                    result.Isbn = createBookModel.Isbn;
                    result.Price = createBookModel.Price;
                    result.PageNo = createBookModel.PageNo;
                    result.Images = createBookModel.Images;
                    _dbContext.SaveChanges();
                    return result;
                }
                return null;
            }
            catch 
            {
                return null;
            }
        }
        public Books Delete(int id)
        {
            try
            {
                var result = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
                if (result != null)
                {
                    _dbContext.Books.Remove(result);
                    _dbContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public Books RetrievbyID(int id)
        {
            try
            {
                var result = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<Books> AllBooks()
        {
            try
            {
                var result = _dbContext.Books.ToList();
                if(result!=null)
                {
                    return result;
                }
                return null;
            }
            catch 
            { 
                return null;
            }  
        }
    }
}
