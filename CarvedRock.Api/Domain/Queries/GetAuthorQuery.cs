using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Queries
{
    public class GetAuthorQuery : IRequest<Author>
    {
        public int AuthorId { get; private set; }
        public GetAuthorQuery (int authorId)
        {
            this.AuthorId = authorId;
        }
    }
}
