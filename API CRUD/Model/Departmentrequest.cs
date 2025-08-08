using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Model
{
    
        public class Departmentrequest
        {
            [Required]
            public string Name { get; set; }
        }
    
}
