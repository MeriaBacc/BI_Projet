using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Project_Dashboard.Models;

namespace Project_Dashboard.Models
{
    public class Stock
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_stock { get; set; }


        [Display(Name = "Nom Stock")]
        [StringLength(50)]
        public string Name_stock { get; set; }

        [Display(Name = "Quantite")]
         public int quantite { get; set; }

        [Display(Name = "Prix Stock")]
        public float Prix_st { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime date_stock { get; set; }
       

        public ICollection<Article> articles { get; set; }


        public Fournisseur fourniseur { get; set; }

        public Admin admin{ get; set; }
    }
}
