using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarvedRock.Api.Domain.Mutation;
using GraphQl_solution.Database;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
namespace CarvedRock.Api.Domain.MutationHandle
{
    public class CreateAuthorMutationHandle : IRequestHandler<CreateAuthorMutation, Author>
    {
        private readonly IAuthorService _authorService;
        public CreateAuthorMutationHandle (IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<Author> Handle(CreateAuthorMutation request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name
            };
            _authorService.AddAuthor(author);
            return author;
        }
    }
}
