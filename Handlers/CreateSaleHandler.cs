using DeveloperStore.API.Data;
using DeveloperStore.API.Models;
using DeveloperStore.API.Requests;
using DeveloperStore.API.Services;
using MediatR;

public class CreateSaleRequestHandler : IRequestHandler<CreateSaleRequest, Sale>
{
    private readonly ApplicationDbContext _context;
    private readonly SaleService _saleService;

    public CreateSaleRequestHandler(ApplicationDbContext context, SaleService saleService)
    {
        _context = context;
        _saleService = saleService;
    }

    public async Task<Sale> Handle(CreateSaleRequest request, CancellationToken cancellationToken)
    {
        // Aplicar as regras de negócio
        var calculatedSale = _saleService.CalculateSale(request.Sale);

        // Salvar a venda no banco de dados
        _context.Sales.Add(calculatedSale);
        await _context.SaveChangesAsync(cancellationToken);

        return calculatedSale;
    }
}
