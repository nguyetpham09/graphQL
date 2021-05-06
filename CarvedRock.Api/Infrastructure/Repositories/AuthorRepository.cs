using GraphQl_solution.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Author AddAuthor(Author author)
        {
           // author.Id = Guid.NewGuid();
           // _context.Add(author);
           // _context.SaveChanges();
           // return author;
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public void DeleteAuthor(int authorId)
        {
            var deleteAuthor = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (deleteAuthor == null)
            {
                return;
            }
            _context.Remove(deleteAuthor);
            _context.SaveChanges();

        }
        public Author EditAuthor(int authorId, Author author)
        {
            var editAuthor = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (editAuthor == null)
            {
                return null;
            }
            editAuthor.Name = author.Name;
            _context.SaveChanges();
            return editAuthor;
        }

        public async Task<List<Author>> GetAll()
        {
            return await Task.FromResult(await _context.Authors.ToListAsync());
        
        }

        public async Task<Author> GetDetail(int id) => await Task.FromResult(
            _context.Authors.FirstOrDefault(i => i.Id == id));

        
    }
}
