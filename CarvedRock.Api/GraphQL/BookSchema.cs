using GraphQL.Types;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

namespace CarvedRock.Api.GraphQL
{
    public class BookSchema : Schema, ISchema
    {
        public BookSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = (IObjectGraphType)resolver.Resolve<BookQuery>();
        }
    }
}
