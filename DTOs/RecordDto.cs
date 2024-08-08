namespace TableManagementAPI.DTOs
{
    public class RecordDto
    {
        public decimal WorkDone { get; set; }
        public int ManDays { get; set; }
        public decimal ManpowerCost { get; set; }
        public decimal EquipmentCost { get; set; }
        public decimal TotalCost { get; set; }
    }
}