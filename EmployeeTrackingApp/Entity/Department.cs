using EmployeeTrackingApp.Entity;
using System.Collections.Generic;

namespace EmployeeTrackingApp.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key for Address
        public int AddressId { get; set; }
        

        public ICollection<Employee> Employee { get; set; }
    }
}
