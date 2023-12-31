using MediatR;

namespace CQRSMediatRExample.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
   
}
