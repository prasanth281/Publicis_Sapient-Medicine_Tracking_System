using Medicine_Tracking_System_WEB_API.Data.Interfaces;
using Medicine_Tracking_System_WEB_API.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB_API.Data.Implementations
{
    public class MedicineData : IMedicineDataAdapter
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly MedicineIdCounter medicineIdCounter;

        public MedicineData(IHostingEnvironment hostingEnvironment, MedicineIdCounter medicineIdCounter)
        {
            _hostingEnvironment = hostingEnvironment;
            this.medicineIdCounter = medicineIdCounter;
        }
        public async Task<int> AddMedicine(Medicine medicine)
        {
            try
            {
                string WebRoot = _hostingEnvironment.ContentRootPath;   
                bool isFileExist = true;
                int NewId = 0;
                string NewPath = string.Empty;
                while (isFileExist)
                {
                    NewId = medicineIdCounter.GetNextId;
                     NewPath = Path.Combine(GetFolderPath(), NewId + ".json");
                    isFileExist = IsFileExist(NewId);


                }
                medicine.ID = NewId;
                string SeriallizedMedicine = JsonConvert.SerializeObject(medicine);
                File.WriteAllText(NewPath, SeriallizedMedicine);
                return medicine.ID;
               // return await  (new Task<int>(() => medicine.ID));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<bool> DeleteMedicineById(int id)
        {
            try
            {
                string WebRoot = _hostingEnvironment.ContentRootPath;
                if (IsFileExist(id))
                {
                    File.Delete(Path.Combine(GetFolderPath(), id + ".json"));

                }
                //medicine.ID = NewId;
                //string SeriallizedMedicine = JsonConvert.SerializeObject(medicine);
                //File.WriteAllText(NewPath, SeriallizedMedicine);
                return true;//await ( new Task<bool>(() => true));
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private bool IsFileExist(int id)
        {
            string WebRoot = _hostingEnvironment.ContentRootPath;
            var Folderpath = Path.Combine(WebRoot, "Data", "JsonDataWithID");
            string NewPath = Path.Combine(Folderpath, id + ".json");
            return  File.Exists(NewPath);
        }
        private string GetFolderPath()
        {
            string WebRoot = _hostingEnvironment.ContentRootPath;
            return Path.Combine(WebRoot, "Data", "JsonDataWithID");
        }
        public async Task<List<Medicine>> GetAllMedicine()
        {
            try
            {
                List<Medicine> medicines = new List<Medicine>();
                string folderpath = GetFolderPath();
                var filenames = Directory.GetFiles(folderpath);
                foreach (var filename in filenames)
                {
                    var filecontent = File.ReadAllText(Path.Combine(folderpath, filename));
                    medicines.Add(JsonConvert.DeserializeObject<Medicine>(filecontent));
                }
                return medicines;//await (new Task<List<Medicine>>(()=>medicines));

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Medicine> GetMedicineByID(int id)
        {
            try
            {
                if (IsFileExist(id))
                {
                    string folderpath = GetFolderPath();
                    var filecontent = File.ReadAllText(Path.Combine(folderpath, id+".json"));
                    return JsonConvert.DeserializeObject<Medicine>(filecontent);//await (new Task<Medicine>(() => JsonConvert.DeserializeObject<Medicine>(filecontent))) ;
                }
                else
                {
                    throw new ArgumentException("No data found");
                }
            }
            catch (Exception)
            {

                throw;
            }
            //throw new NotImplementedException();
        }

        public async Task<bool> UpdateMedicine(Medicine medicine)
        {
            try
            {
                if (IsFileExist(medicine.ID))
                {
                    string folderpath = GetFolderPath();
                    string SeriallizedMedicine = JsonConvert.SerializeObject(medicine);
                    File.WriteAllText(Path.Combine(folderpath, medicine.ID + ".json"), SeriallizedMedicine);
                    return true;//await (new Task<bool>(() => true)) ;
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
