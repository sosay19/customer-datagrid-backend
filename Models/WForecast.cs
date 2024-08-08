using Microsoft.AspNetCore.Mvc;
using customer_datagrid_backend.Models;

namespace customer_datagrid_backend.Models
{
    public class WForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
