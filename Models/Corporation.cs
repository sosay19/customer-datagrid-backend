namespace customer_datagrid_backend.Models
{
    public class Corporation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
