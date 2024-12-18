using GraphQL.Types;

namespace WebApiGraphql.Services;

public sealed class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInputType";
        Field<IntGraphType>("id");
        Field<StringGraphType>("name");
    }
}