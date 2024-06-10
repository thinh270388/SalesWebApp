using Microsoft.AspNetCore.Components;
using SalesModels;
using SalesWasm.Services;

namespace SalesWasm.Pages
{
    public partial class Product
    {
        [Inject] private IProductApiClient productApiClient {  get; set; }

        private List<ProductDto> productDtos;

        protected override async Task OnInitializedAsync()
        {
            productDtos = await productApiClient.GetAll();
        }
    }
}
