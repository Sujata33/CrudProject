using System.ComponentModel.DataAnnotations;

namespace CrudProject.Models
{
    public class Banks
    {
        [Key]
        public Guid Id { get; set; }
        public String ref_code { get; set; }
        public String name { get; set; }

        public string short_name { get; set; }

        public string intigrated_yn { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        

    }
}
