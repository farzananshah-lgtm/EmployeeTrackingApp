using EmployeeTrackingApp.Entity;

using System.Collections.Generic;

namespace EmployeeTrackingApp.Entity

{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }
}

