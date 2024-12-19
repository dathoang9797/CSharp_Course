using GraphQL.Types;
using WebApiGraphql.Models;

namespace WebApiGraphql.Services;

public sealed class CategoryType : ObjectGraphType<Category>
{
    public CategoryType()
    {
        Field(p => p.Id, type: typeof(IntGraphType)).Description("Id Property for Category object");
        Field(p => p.Name, type: typeof(StringGraphType)).Description("Name Property for Category object");
    }
}