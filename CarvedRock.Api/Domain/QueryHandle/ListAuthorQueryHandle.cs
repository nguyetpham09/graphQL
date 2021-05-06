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
    public class ListAuthorQueryHandle : IRequestHandler<ListAuthorQuery, IEnumerable<Author>>
    {
        private readonly IAuthorService _authorService;
        public ListAuthorQueryHandle(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IEnumerable<Author>> Handle(ListAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAll();
        }
    }
}
