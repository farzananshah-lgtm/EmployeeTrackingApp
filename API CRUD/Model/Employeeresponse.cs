namespace API_CRUD.Model
{
    public class Employeeresponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DepartmentName { get; set; } // <- This is not getting filled
        public string AddressStreet { get; set; }
    }
}
