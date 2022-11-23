namespace ManagementUI.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<ConcentrationVM> SelectedDrugsConcentrations = new();
    }
}
