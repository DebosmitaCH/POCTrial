using System;
using System.Collections.Generic;

#nullable disable

namespace POCTrial.Models
{
    public partial class EmployeeInformation
    {
        public short EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Supervisor { get; set; }
        public DateTime StartDate { get; set; }
        public string ProjectId { get; set; }
        public string WorkEmail { get; set; }
        public string WorkLocation { get; set; }
        public string WorkPhone { get; set; }

    }
}
