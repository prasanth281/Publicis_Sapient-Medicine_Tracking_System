using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB_API.Data.Models
{
    public class MedicineIdCounter
    {
        private int ID { get; set; }
        public int GetNextId { get { return ID++; } }
        public int GetCurrentId { get { return ID; } }

    }
}
