using DeveloperStore.API.Models;
using MediatR;

namespace DeveloperStore.API.Requests
{
    public class CreateSaleRequest : IRequest<Sale>
    {
        public Sale Sale { get; set; }

        public CreateSaleRequest(Sale sale)
        {
            Sale = sale;
        }
    }
}
