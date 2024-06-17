

using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GerPoductsByCategoryQueryHandler.handle called with {query}");
            var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category)).ToListAsync(cancellationToken);
            //products =  products.Where(p => p.Category.Contains(query.Category)).ToList();
            return new GetProductByCategoryResult(products);
        }
    }
}
