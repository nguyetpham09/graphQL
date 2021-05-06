using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using MediatR;
namespace CarvedRock.Api.Domain.Queries
{
    public class ListAuthorQuery : IRequest<IEnumerable<Author>> 
    {

    }
}
