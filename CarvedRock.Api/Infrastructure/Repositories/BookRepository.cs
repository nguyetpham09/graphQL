using GraphQl_solution.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAll()
        {
            return await Task.FromResult(await _context.Books.ToListAsync());
        }

        public async Task<Book> GetDetail(int id)
        {
            return await Task.FromResult( _context.Books.FirstOrDefault(i => i.Id == id));
        }
        

        public async Task<List<Book>> GetBooksByAuthorId(int authorId)
        {
            return await (from b in _context.Books join a in _context.Authors on b.AuthorId equals a.Id where a.Id == authorId select b).ToListAsync();
            
        }
        public async Task<List<Book>> GetBooksByAuthorIds(List<int> authorIds)
        {
            return await Task.FromResult(_context.Books.Where(e => authorIds.Contains(e.AuthorId)).ToList());
        }

    }
}
