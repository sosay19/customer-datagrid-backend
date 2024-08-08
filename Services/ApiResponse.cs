namespace customer_datagrid_backend.Services
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

}
