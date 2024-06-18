using Catalog.API.Products.UpdateProduct;
using Mapster;

namespace Catalog.API.Products.DeleteProductById
{
    //public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool response);
    public class DeleteProductByIdEndpoint : ICarterModule
    {
     public void AddRoutes(IEndpointRouteBuilder app)
     {
        app.MapDelete("/products/{Id}",async (Guid Id, ISender sender) =>
        {

       var result = await sender.Send(new DeleteProductByIdCommand(Id));
       var response = result.Adapt<DeleteProductResponse>();
       return Results.Ok(response);

       
        })
.WithName("DeleteProduct")
.Produces<UpdateProductResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.WithSummary("Delete Product")
.WithDescription("Delete Product");
        }
    }
}
