﻿namespace ManagementUI.ViewModels
{
    public class ProductVM
    {
        public string? Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string? MeasurementUnitId { get; set; }
        public List<ConcentrationVM> SelectedDrugsConcentrations = new();
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int TotalStockQuantity { get; set; }
    }
}
