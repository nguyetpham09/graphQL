using GraphQL.Types;
using GraphQl_solution.Database;
using GraphQl_solution.GraphQL;
using GraphQl_solution.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IAuthorService services)
        {
            Name = "Book";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Book");
            Field(x => x.Name).Description("The name of the book");
            Field(x => x.Genre).Description("Book genre");
            Field(x => x.Published).Description("If the book is published or not");
            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
                resolve: context => services.GetDetail(context.GetArgument<int>("id")));
        }

    }

}
