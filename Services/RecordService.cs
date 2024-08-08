using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TableManagementAPI.Models;
using TableManagementAPI.DTOs;
using customer_datagrid_backend.Data;

namespace TableManagementAPI.Services
{
    public class RecordService : IRecordService
    {
        private readonly ApplicationDbContext _context;

        public RecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Record>> GetAllRecords() => await _context.Records.ToListAsync();

        public async Task<Record> GetRecordById(int id) => await _context.Records.FindAsync(id);

        public async Task<Record> AddRecord(RecordDto newRecord)
        {
            var record = new Record
            {
                DummyWorkDone = newRecord.WorkDone,
                DummyManDays = newRecord.ManDays,
                DummyManpowerCost = newRecord.ManpowerCost,
                DummyEquipmentCost = newRecord.EquipmentCost,
                DummyTotalCost = newRecord.TotalCost
            };
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<Record> UpdateRecord(int id, RecordDto updatedRecord)
        {
            var record = await _context.Records.FindAsync(id);
            if (record != null)
            {
                record.DummyWorkDone = updatedRecord.WorkDone;
                record.DummyManDays = updatedRecord.ManDays;
                record.DummyManpowerCost = updatedRecord.ManpowerCost;
                record.DummyEquipmentCost = updatedRecord.EquipmentCost;
                record.DummyTotalCost = updatedRecord.TotalCost;

                _context.Records.Update(record);
                await _context.SaveChangesAsync();
            }
            return record;
        }

        public async Task<bool> DeleteRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record != null)
            {
                _context.Records.Remove(record);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
