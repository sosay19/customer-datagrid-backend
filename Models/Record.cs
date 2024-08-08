using customer_datagrid_backend.Models;

namespace TableManagementAPI.Models
{
    public class Record
    {

        public int Id { get; set; }
        public string DummyCorpName { get; set; }
        public string DummyDistrictName { get; set; }
        public decimal DummyWorkDone { get; set; }
        public int DummyManDays { get; set; }
        public decimal DummyManpowerCost { get; set; }
        public decimal DummyEquipmentCost { get; set; }
        public decimal DummyTotalCost { get; set; }
        public Project Project { get; set; }
    }
}
