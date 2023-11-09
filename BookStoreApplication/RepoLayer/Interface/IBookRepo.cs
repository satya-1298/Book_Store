using CommonLayer.Model;
using RepoLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface  IBookRepo
    {
        public Books Creation(CreateBookModel createBookModel);
        public Books Update(CreateBookModel createBookModel, int id);
        public Books Delete(int id);
        public Books RetrievbyID(int id);
        public List<Books> AllBooks();

    }
}
