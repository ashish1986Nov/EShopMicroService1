using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(  string Name , string Description ,List<string> Category
        , string ImageFile , decimal Price ) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
