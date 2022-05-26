using Medicine_Tracking_System_WEB.Data;
using Medicine_Tracking_System_WEB.Data.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_Tracking_System_WEB.Pages
{
    public partial class AddMedicine
    {
        [Parameter]
        public int MedID { get; set; }

        protected string Title = "Add";
        [Inject]
        public IMedicineDataAdapter _medicineDataAdapter { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        public Medicine Med = new Medicine();

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnParametersSetAsync()
        {
            if (MedID != 0)
            {
                Title = "Edit";
                Med = await _medicineDataAdapter.GetById(MedID);
            }
        }

        

        protected async Task SaveMedicine()
        {
            if (Med.ID != 0)
            {
                bool IsUpdated = false;
                await Task.Run(async () =>
                {
                    IsUpdated= await _medicineDataAdapter.UpdateMedicine(Med);
                });
            }
            else
            {
                await Task.Run(async () =>
                {
                   int id= await _medicineDataAdapter.AddNewMedicine(Med);
                });
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/");
        }
    }
}

