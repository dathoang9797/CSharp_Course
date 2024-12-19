using GraphQL;
using GraphQL.Types;
using WebApiGraphql.Models;

namespace WebApiGraphql.Services
{
    public class CategoryQuery : ObjectGraphType<Category>
    {
        public CategoryQuery(WebStoreContext context)
        {
            Field<ListGraphType<CategoryType>>(
                name: "categories",
                resolve: p => context.Categories.ToList());

            Field<CategoryType>(
                name: "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "id",
                        Description = "Category Id"
                    }
                ),
                resolve: p => context.Categories.Find(p.GetArgument<int>("id"))
            );
        }
    }
}