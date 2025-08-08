namespace BlazorApp2.Models
{
    public class EmployeeRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEmployment { get; set; }

        // Address info
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Department info
        public string DepartmentName { get; set; }
    }
}
