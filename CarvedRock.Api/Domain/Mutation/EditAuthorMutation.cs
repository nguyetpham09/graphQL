using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Mutation
{
    public class EditAuthorMutation : IRequest<Author>
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public EditAuthorMutation (int authorId, Author author)
        {
            AuthorId = authorId;
            Author = author;
        }
    }
}
