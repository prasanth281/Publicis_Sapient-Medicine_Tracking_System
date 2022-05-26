using Medicine_Tracking_System_WEB_API.Data.Interfaces;
using Medicine_Tracking_System_WEB_API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medicine_Tracking_System_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineDataAdapter medicineDataAdapter;

        public MedicineController(IMedicineDataAdapter _medicineDataAdapter)
        {
            medicineDataAdapter = _medicineDataAdapter;
        }
        // GET: api/<MedicineController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Medicine> MedDetails = await medicineDataAdapter.GetAllMedicine();
                return new OkObjectResult(MedDetails);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

        }

        // GET api/<MedicineController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Medicine MedDetails = await medicineDataAdapter.GetMedicineByID(id);
                return new OkObjectResult(MedDetails);
            }

            catch (Exception)
            {
                return new BadRequestResult();
            }

        }

        // POST api/<MedicineController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Medicine medicine)
        {
            try
            {
                int Id = await medicineDataAdapter.AddMedicine(medicine);
                return new OkObjectResult(Id);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

        }

        // PUT api/<MedicineController>/
        [HttpPut]
        public async Task<IActionResult> Put(Medicine medicine)
        {
            try
            {
                bool IsAdded = await medicineDataAdapter.UpdateMedicine(medicine);
                return new OkObjectResult(IsAdded);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

        }

        // DELETE api/<MedicineController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool IsAdded = await medicineDataAdapter.DeleteMedicineById(id);
                return new OkObjectResult(IsAdded);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

        }
    }
}
