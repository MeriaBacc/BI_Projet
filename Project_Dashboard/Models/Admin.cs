using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Project_Dashboard.Models;



namespace Project_Dashboard.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_admin { get; set; }

        [Display(Name = "Mot de passe")]
        [StringLength(50)]
        public string password { get; set; }

        public ICollection<Stock> Stocks  { get; set; }
        public ICollection<Client> clients { get; set; }
        public ICollection<Article> articles { get; set; }





    }
}
