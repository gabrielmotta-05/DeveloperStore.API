using DeveloperStore.API.Models;
using MediatR;

namespace DeveloperStore.API.Requests
{
    public class GetSaleByIdRequest : IRequest<Sale>
    {
        public int SaleId { get; set; }

        public GetSaleByIdRequest(int saleId)
        {
            SaleId = saleId;
        }
    }
}
