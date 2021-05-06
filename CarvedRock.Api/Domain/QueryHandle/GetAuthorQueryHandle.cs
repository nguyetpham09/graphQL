using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarvedRock.Api.Domain.Queries;
using GraphQl_solution.Database;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
namespace CarvedRock.Api.Domain.Handle
{
    public class GetAuthorQueryHandle : IRequestHandler<GetAuthorQuery, Author>
    {
        private readonly IAuthorService _authorService;
        public GetAuthorQueryHandle (IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            if (request.AuthorId <= 0)
            {
                throw new ArgumentException(nameof(request.AuthorId));
            }
            return await _authorService.GetDetail(request.AuthorId);
        }
    }
}
