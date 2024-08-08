using TableManagementAPI.Models;

namespace customer_datagrid_backend.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CorporationId { get; set; }
        public int DistrictId { get; set; }

        public Corporation Corporation { get; set; }
        public District District { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
