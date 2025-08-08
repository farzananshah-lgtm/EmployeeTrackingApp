namespace API_CRUD.Model
{
    public class EmployeeRequest
    {
        public string Email { get; set; }             // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEmployment { get; set; }

        // Address Info
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Department Info
        public string DepartmentName { get; set; }
    }
}
