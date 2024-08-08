using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementAPI.DTOs;
using TableManagementAPI.Models;

namespace TableManagementAPI.Services
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetAllRecords();
        Task<Record> GetRecordById(int id);
        Task<Record> AddRecord(RecordDto newRecord);
        Task<Record> UpdateRecord(int id, RecordDto updatedRecord);
        Task<bool> DeleteRecord(int id);
    }
}
