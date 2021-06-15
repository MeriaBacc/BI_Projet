using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Dashboard.Models
{
    public class Fournisseur
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_fournisseur { get; set; }

        [Display(Name = "Nom Fournisseur")]
        [StringLength(50)]
        public string Name_fournisseur { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(50)]
        public string tele_fournisseur { get; set; }

        

        public ICollection<Stock> stockss { get; set; }

    }
}
