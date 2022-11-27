using ManagementUI.ViewModels;

namespace ManagementUI.Services.IServices
{
    public interface IProducsService
    {
        Task<ProductVM> CreateNewProduct(ProductVM productVM);
        Task<ProductVM> UpdateProduct(ProductVM productVM);
        Task<List<ProductVM>> SearchProductByName(string partialName);
        Task<ProductVM> GetProductById(string productId);
    }
}
