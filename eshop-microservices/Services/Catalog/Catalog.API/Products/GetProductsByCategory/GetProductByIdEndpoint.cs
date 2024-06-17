
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductsByCategoryRequest(string Category);
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{Category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductsByCategoryResponse>();

                return Results.Ok(response);
            })
       .WithName("GetProductsByCategory")
       .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Get Product by Category")
       .WithDescription("Get Product by Category");
        }
    }
}
