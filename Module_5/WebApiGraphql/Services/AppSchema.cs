using GraphQL.Types;

namespace WebApiGraphql.Services;

public class AppSchema : Schema
{
    public AppSchema(CategoryQuery query, CategoryMutation mutation) =>
        (Query, Mutation) = (query, mutation);
}