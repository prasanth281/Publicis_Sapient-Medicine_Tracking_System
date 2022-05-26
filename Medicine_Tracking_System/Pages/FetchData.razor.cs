using Medicine_Tracking_System_WEB.Data;
using Medicine_Tracking_System_WEB.Data.Models;
using Medicine_Tracking_System_WEB.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB.Pages
{
    public partial class FetchData
    {
        //public FetchData(IMedicineDataAdapter medicineDataAdapter)
        //{
        //    _medicineDataAdapter = medicineDataAdapter;
        //}
        protected override async Task OnInitializedAsync()
        {
            AllMedicines  =await _medicineDataAdapter.GetAllMedicines();
            MedList = AllMedicines;
        }
        public string SearchString { get; set; } = string.Empty;
        public List<Medicine> MedList { get; set; } = new List<Medicine>();
        public Medicine Med { get; set; } = new Medicine();
        bool showDeletePopUp =false;
        [Inject]
        public IMedicineDataAdapter _medicineDataAdapter { get; set; }
        public List<Medicine> AllMedicines { get; set; } = new List<Medicine>();

        public async Task FilterMed()
        {
            MedList = AllMedicines.Where(itm => itm.MedicineText?.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ?? false).ToList() ?? new List<Medicine>();
        }
        public async Task ResetSearch()
        {
            SearchString = string.Empty;
            MedList = AllMedicines;
        }
        
        public async Task DeleteConfirm(int id)
        {
            Med = AllMedicines.Where(itm => itm.ID == id).FirstOrDefault();
            showDeletePopUp = true;
            await InvokeAsync(StateHasChanged);
        }
        public async Task CloseModel()
        {
            showDeletePopUp = false;
            await InvokeAsync(StateHasChanged);
        }
        public async Task DeleteMedicine(int id)
        {
            bool Isdeleted = await _medicineDataAdapter.DeleteMedicine(id);
            showDeletePopUp = false;
            await InvokeAsync(StateHasChanged);
            AllMedicines = await _medicineDataAdapter.GetAllMedicines();
            MedList = AllMedicines;
            await InvokeAsync(StateHasChanged);

        }


    }
}
