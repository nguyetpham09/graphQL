using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarvedRock.Api.Domain.Queries;
using CarvedRock.Api.Infrastructure.Services;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Handle
{
    public class GetBooksByAuthorIdQueryHandle : IRequestHandler<GetBooksByAuthorIdQuery, List<Book>>
    {
        private readonly IBookService _bookService;
        public GetBooksByAuthorIdQueryHandle (IBookService bookService)
        {
            _bookService = bookService;
        }
        public Task<List<Book>> Handle(GetBooksByAuthorIdQuery request, CancellationToken cancellationToken)
        {
           
            return _bookService.GetBooksByAuthorId(request.AuthorId);
        }
    }
}
