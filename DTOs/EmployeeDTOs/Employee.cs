using System;

namespace StaffRegistrationPortal.DTOs
{
    public class Employee
    {


        public int Id { get; set; }

        public int UserId { get; set; }

        public string DobUploadPath { get; set; }

        public string CertificateUploadPath { get; set; } 

        public string PassportUploadPath { get; set; } 

        public string EmploymentStatus { get; set; } 

        public string MaritalStatus { get; set; } 

        public int WorkingExperience { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Disability { get; set; } 

        public string MedicalRecordUploadPath { get; set; } 

        public string NationalIDcode { get; set; } 

        public string Nationality { get; set; } 

        public string IdUploadPath { get; set; } 
        public string CreatedBy { get; set; } 


        public string UpdatedBy { get; set; } 

        public bool IsUpdated { get; set; }

        public string DeletedBy { get; set; } 

        public bool IsDeleted { get; set; }



    }

  

  
   
        /*{
      "id": 0,
      "userId": 1,
      "dobUploadPath": "https://localhost:7023/swagger/index.html",
      "certificateUploadPath": "https://localhost:7023/swagger/index",
      "passportUploadPath": "https://localhost:7023/swagger/index.html",
      "employmentStatus": "Full-time",
      "maritalStatus": "Single",
      "workingExperience": 5,
      "height": 10,
      "weight": 11,
      "disability": "None",
      "medicalRecordUploadPath": "https://localhost:7023/swagger/index.html",
      "nationalIDcode": "jj234j4j43",
      "nationality": "Nigeria",
      "idUploadPath": "https://localhost:7023/swagger/index.html",
      "createdBy": "John@gmail.com"
    }
    */


    }
