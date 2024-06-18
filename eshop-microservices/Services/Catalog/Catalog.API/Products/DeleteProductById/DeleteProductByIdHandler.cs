

using Catalog.API.Exceptions;

namespace Catalog.API.Products.DeleteProductById
{
    public record DeleteProductByIdCommand(Guid Id) : ICommand<DeleteProductByIdResult>;

    public record DeleteProductByIdResult ( bool response);
    public class DeleteProductByIdHandler (IDocumentSession session) : ICommandHandler<DeleteProductByIdCommand, DeleteProductByIdResult>
    {
        public async Task<DeleteProductByIdResult> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if(product is null)
            {
                throw new ProductNotFoundException();
            }
            session.Delete(product);
            session.SaveChanges();
            return new DeleteProductByIdResult(true);
        }
    }
}
