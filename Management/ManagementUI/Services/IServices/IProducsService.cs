using ManagementUI.ViewModels;

namespace ManagementUI.Services.IServices
{
    public interface IProducsService
    {
        Task CreateNewProduct(ProductVM productVM);
    }
}
