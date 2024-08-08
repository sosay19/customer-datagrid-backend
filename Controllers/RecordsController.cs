using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TableManagementAPI.Services;
using TableManagementAPI.Models;
using TableManagementAPI.DTOs;

namespace TableManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Record>> GetAllRecords()
        {
            return Ok(new { data = _recordService.GetAllRecords(), status = "success", message = "Records retrieved successfully." });
        }

        [HttpGet("{id}")]
        public ActionResult<Record> GetRecordById(int id)
        {
            var record = _recordService.GetRecordById(id);
            if (record == null)
                return NotFound(new { status = "error", message = "Record not found." });

            return Ok(new { data = record, status = "success", message = "Record retrieved successfully." });
        }

        [HttpPost]
        public ActionResult<Record> AddRecord([FromBody] RecordDto newRecord)
        {
            var record = _recordService.AddRecord(newRecord);
            return CreatedAtAction(nameof(GetRecordById), new { id = record.Id }, new { data = record, status = "success", message = "Record added successfully." });
        }

        [HttpPut("{id}")]
        public ActionResult<Record> UpdateRecord(int id, [FromBody] RecordDto updatedRecord)
        {
            var record = _recordService.UpdateRecord(id, updatedRecord);
            if (record == null)
                return NotFound(new { status = "error", message = "Record not found." });

            return Ok(new { data = record, status = "success", message = "Record updated successfully." });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecord(int id)
        {
            var result = _recordService.DeleteRecord(id);
            if (!result.Result)
                return NotFound(new { status = "error", message = "Record not found." });

            return Ok(new { status = "success", message = "Record deleted successfully." });
        }
    }
}
