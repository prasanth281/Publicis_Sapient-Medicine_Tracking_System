# Publicis_Sapient-Medicine_Tracking_System
Medicine Tracking System Assignment from Publicis Sapient 

# This Repo contains both API and WEB project 

# Please set both projects as Start up projects

Target Framework 
--------
.Net core - 3.1 



APIs
-----------
1. Get All Medicines - GET https://localhost:44306/api/Medicine/
2. Get MedicineById - GET https://localhost:44306/api/Medicine/2
3. Insert New Medicine - Post https://localhost:44306/api/Medicine/
   i. Request Body : {
    "MedicineText" : "DOLO 650",
    "Brand" : "Cipla",
    "Price": 160,
    "Quantity":20,
    "ExpiryDate":"2022-05-26"
    }
 4. Update Medicine - PUT 
    i. Request Body 
    {
    "MedicineText" : "DOLO 650",
    "Brand" : "Cipla",
    "Price": 160,
    "Quantity":20,
    "ExpiryDate":"2022-05-26",
    "ID":2
    }
    
 5. Delete Medicine - DELETE https://localhost:44306/api/Medicine/2

# All APIs produce JSON type with Http code ( 200 -OK or 400 Bad Request )


Please connect to me for code issues - Prasanth8185@yahoo.com

