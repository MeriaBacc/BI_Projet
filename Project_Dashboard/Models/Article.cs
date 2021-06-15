using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Dashboard.Models
{
    public class Article
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Article { get; set; } 

        [Display(Name ="Nom Article")]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Display(Name = "Prix Article")]
        public float Prix  { get; set; }

        [Display(Name = "Pourcentage Article")]
        public float Pourcentage { get; set; }

        [Display(Name = "Categorie Article")]
        [StringLength(50)]
        public string Categorie { get; set; }


        // foreing key facture 
       
        public Facture facture { get; set; }


        // foreing key stock
        
        public Stock stock { get; set; }


    }
}
