using ManagementUI.ViewModels;

namespace ManagementUI.Services.IServices
{
    public interface IMeasurementUnitsService
    {
        Task<List<MeasurementUnitVM>> GetAll();
    }
}
