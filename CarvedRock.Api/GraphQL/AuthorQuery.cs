using CarvedRock.Api.GraphQL;
using GraphQL;
using GraphQL.Types;
using GraphQl_solution.Database;
using GraphQl_solution.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CarvedRock.Api.Domain.Queries;
using CarvedRock.Api.Domain.Mutation;

namespace GraphQl_solution.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(IMediator mediator)
        {
            
            Field<ListGraphType<AuthorType>>(
                "Authors",
               resolve: context =>
                {
                    return mediator.Send(new ListAuthorQuery()) ;
                }
                );
            
            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Author" }
                    ),
                resolve: context =>
                {
                    return  mediator.Send(new GetAuthorQuery(context.GetArgument<int>("id")));
                }
                );
            Field<ListGraphType<BookType>>(
                "Books",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Author" }
                    ),
                resolve: context =>
                {
                    return mediator.Send(new GetBooksByAuthorIdQuery(context.GetArgument<int>("id")));
                });
        }
    }
}
