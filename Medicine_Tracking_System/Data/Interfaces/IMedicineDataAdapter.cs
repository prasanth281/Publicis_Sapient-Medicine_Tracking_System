using Medicine_Tracking_System_WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB.Data
{
    public interface IMedicineDataAdapter
    {
       Task<List<Medicine>> GetAllMedicines();
        Task<bool> DeleteMedicine(int id);
        Task<Medicine> GetById(int medID);
        Task<bool> UpdateMedicine(Medicine med);
        Task<int> AddNewMedicine(Medicine med);
    }
}
