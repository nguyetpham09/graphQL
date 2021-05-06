using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetDetail(int id);
        Author AddAuthor(Author author);
        Author EditAuthor(int authorId, Author author);
        void DeleteAuthor(int authorId);
    }
}
