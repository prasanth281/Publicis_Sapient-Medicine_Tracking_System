using Medicine_Tracking_System_WEB_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB_API.Data.Interfaces
{
    public interface IMedicineDataAdapter
    {
        public Task<List<Medicine>> GetAllMedicine();
        Task<Medicine> GetMedicineByID(int id);
        Task<int> AddMedicine(Medicine medicine);
        Task<bool> UpdateMedicine(Medicine medicine);
        Task<bool> DeleteMedicineById(int id);
    }
}
