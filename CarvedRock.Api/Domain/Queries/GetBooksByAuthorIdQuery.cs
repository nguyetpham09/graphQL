using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Queries
{
    public class GetBooksByAuthorIdQuery : IRequest<List<Book>>
    {
        

        public int AuthorId { get; private set; }
        public GetBooksByAuthorIdQuery (int authorId)
        {
            AuthorId = authorId;
        }

        
    }
}
