using System.ComponentModel.DataAnnotations;

namespace API_CRUD.Model
{
    public class Addressrequest
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public string Country { get; set; }

    }
}

