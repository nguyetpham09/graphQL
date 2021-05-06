using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using GraphQl_solution.GraphQL;
using CarvedRock.Api.Domain.Mutation;
using GraphQl_solution.Database;

namespace CarvedRock.Api.GraphQL
{
    public class AuthorMutation : ObjectGraphType
    {
        public AuthorMutation(IMediator mediator)
        {
            Field<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
                resolve: context =>
                {
                    var author = context.GetArgument<string>("author");
                    return mediator.Send(new CreateAuthorMutation(author));
                }
               );

        }
    }

    }
