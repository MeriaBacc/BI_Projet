using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Dashboard.Models
{
    public class Client
    {


            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id_Client { get; set; }


            [Display(Name = "Nom Client")]
            [StringLength(50)]
            public string nomc { get; set; }


            [Display(Name = "Adresse Client")]
            [StringLength(50)]
            public string tele { get; set; }


            [Display(Name = "Age")]
            [StringLength(50)]
            public int age { get; set; }


        public ICollection<Facture> facture { get; set; }



    }
}