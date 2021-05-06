using CarvedRock.Api.Infrastructure.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookService service)
        {
            Field<ListGraphType<BookType>>(
                "Books",
                resolve: context => service.GetAll());
        }
    }
}
