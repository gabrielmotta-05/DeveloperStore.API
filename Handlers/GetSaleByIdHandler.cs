using DeveloperStore.API.Data;
using DeveloperStore.API.Models;
using DeveloperStore.API.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.API.Handlers
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdRequest, Sale>
    {
        private readonly ApplicationDbContext _context;

        public GetSaleByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> Handle(GetSaleByIdRequest request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.Include(s => s.Items)
                                           .FirstOrDefaultAsync(s => s.Id == request.SaleId, cancellationToken);

            if (sale == null)
            {
                throw new KeyNotFoundException($"Venda com ID {request.SaleId} não encontrada.");
            }

            return sale;
        }
    }
}
