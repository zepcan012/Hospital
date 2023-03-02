using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
     public class PatientModelRest
     {
        public Guid patientID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string diagnosis { get; set; }

        public string identificationNumber { get; set; }

        public string medicalRecordNumber { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public DateTime deletedAt { get; set; }
    }
}
