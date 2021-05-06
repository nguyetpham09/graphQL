using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Mutation
{
    public class CreateAuthorMutation : IRequest<Author> 
    {
        //public Author Author { get; set; }
        public string Name { get; set; }
        public CreateAuthorMutation (string name)
        {
            Name = name;
        }
    }
}
