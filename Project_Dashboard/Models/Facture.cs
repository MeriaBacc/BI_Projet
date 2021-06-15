using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Dashboard.Models
{
    public class Facture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Facture { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime date_facture { get; set; }

        [Display(Name = "Prix Facture")]
        public float prix_facture { get; set; }

        [Display(Name = "Nombre Article")]
        public int Nbre_article { get; set; }


        // foreing key client
      
        public Client client { get; set; }



        public ICollection<Article> article  { get; set; }

    }
}
