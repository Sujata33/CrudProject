using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProject.Models
{
    public class Branches
    {
        [Key]
        public Guid id { get; set; }
        public string ref_code { get; set; }
        public string name { get; set; }
        public string ifsc { get; set; }
        public string address { get; set; }

        [ForeignKey("Banks")]
        public Guid bank_id { get; set; }

        public Banks Banks { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


    }
}
