using CarvedRock.Api.Infrastructure.Repositories;
using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        
        public AuthorService(IAuthorRepository repo)
        {
            _authorRepository = repo;
        }
        public async Task<Author> GetDetail(int id)
        {
            return await _authorRepository.GetDetail(id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public Author AddAuthor(Author author)
        {
            return _authorRepository.AddAuthor(author);
        }
    }
}
