using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB_API.Data.Models
{
    public class Medicine
    {
        public string MedicineText { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public int ID { get; set; }
    }
}
