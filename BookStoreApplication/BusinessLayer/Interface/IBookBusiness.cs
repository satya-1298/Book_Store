using CommonLayer.Model;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBusiness
    {
        public Books Creation(CreateBookModel createBookModel);
        public Books Update(CreateBookModel createBookModel, int id);
        public Books Delete(int id);
        public Books RetrievbyID(int id);
        public List<Books> AllBooks();
    }
}
