namespace Catalog.API.Products.CreateProduct
{
    // represents the data that we need to create for a new product

    // record  os a class or struct that provides special syntax and behavior for working with data models
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
public record CreateProductResult(Guid ID); // represents the response object

    // Handler is responsible for executing the command logic using the mediatR library
    internal class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // business logic to create a product

            // create product entity from command object 
                        
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price.ToString(),
            };

            // save to db  TODO
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // return createProductResult result

            return new  CreateProductResult(product.Id);
        }
    }
}
