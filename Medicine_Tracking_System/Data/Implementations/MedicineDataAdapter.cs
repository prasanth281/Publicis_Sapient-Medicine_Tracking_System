using Medicine_Tracking_System_WEB.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB.Data
{
    public class MedicineDataAdapter : IMedicineDataAdapter
    {
        private readonly HttpClient httpClient;
        public MedicineDataAdapter(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> AddNewMedicine(Medicine med)
        {
            try
            {
                var res = await httpClient.PostAsync("api/Medicine/",new StringContent (JsonConvert.SerializeObject(med), Encoding.UTF8, "application/json"));
                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<int>(await res.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteMedicine(int id)
        {
            try
            {
                var res = await httpClient.DeleteAsync($"api/Medicine/{id}");
                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<bool>(await res.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<List<Medicine>> GetAllMedicines()
        {
            try
            {
                var res = await httpClient.GetAsync("api/Medicine");
                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<Medicine>>( await res.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public async Task<Medicine> GetById(int medID)
        {
            try
            {
                var res = await httpClient.GetAsync($"api/Medicine/{medID}");
                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<Medicine>(await res.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateMedicine(Medicine med)
        {
            try
            {
                var res = await httpClient.PutAsync("api/Medicine/", new StringContent(JsonConvert.SerializeObject(med), Encoding.UTF8, "application/json"));
                res.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<bool>(await res.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
