using CarvedRock.Api.Infrastructure.Repositories;
using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService (IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Book>> GetBooksByAuthorId(int authorId)
        {
            return await _repository.GetBooksByAuthorId(authorId);
        }

        public async Task<List<Book>> GetBooksByAuthorIds(List<int> authorIds)
        {
            return await _repository.GetBooksByAuthorIds(authorIds);
        }

        public async Task<Book> GetDetail(int id)
        {
            return await _repository.GetDetail(id);
        }
    }
}
