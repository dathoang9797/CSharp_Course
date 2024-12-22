using GraphQL;
using GraphQL.Types;
using WebApiGraphql.Models;

namespace WebApiGraphql.Services;

public class CategoryMutation : ObjectGraphType<Category>
{
    public CategoryMutation(WebStoreContext context)
    {
        Field<CategoryType>(
            name: "addCategory",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CategoryInputType>>
                {
                    Name = "category",
                    Description = "Category input parameter"
                }
            ),
            resolve: p =>
            {
                var obj = p.GetArgument<Category>("category");
                if (obj != null)
                {
                    context.Categories.Add(obj);
                    context.SaveChanges();
                    return obj;
                }

                return null;
            });
        Field<IntGraphType>(name: "addCategory2", arguments: new QueryArguments(
            new QueryArgument<NonNullGraphType<IntGraphType>>
            {
                Name = "id",
                Description = "Id Field"
            },
            new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "name",
                Description = "Name Field"
            }
        ), resolve: p =>
        {
            var name = p.GetArgument<string>("name");
            if (string.IsNullOrEmpty(name))
                return -1;

            context.Categories.Add(new Category
            {
                Id = p.GetArgument<int>("id"),
                Name = name
            });

            return context.SaveChanges();
        });
        Field<CategoryType>(
            name: "editCategory",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CategoryInputType>>
                {
                    Name = "category",
                    Description = "Category input parameter"
                }
            ),
            resolve: p =>
            {
                var obj = p.GetArgument<Category>("category");
                if (obj != null)
                {
                    context.Categories.Update(obj);
                    context.SaveChanges();
                    return obj;
                }

                return null;
            });
        Field<CategoryType>(
            name: "deleteCategory",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>>
                {
                    Name = "id",
                    Description = "id input parameter"
                }
            ),
            resolve: p =>
            {
                var id = p.GetArgument<int>("id");
                var obj = context.Categories.Find(id);
                if (obj != null)
                {
                    context.Categories.Remove(obj);
                    context.SaveChanges();
                    return obj;
                }

                return null;
            });
    }
}