using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB.Data.Models
{
    public class Medicine
    {
        [Required]
        public string MedicineText { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public DateTime ExpiryDate { get; set; } = DateTime.Today;
        public string Notes { get; set; }
        public int ID { get; set; }
    }
}
