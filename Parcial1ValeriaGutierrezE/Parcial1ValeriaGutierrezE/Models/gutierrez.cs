using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1ValeriaGutierrezE.Models
{
    public class gutierrez
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(30,MinimumLength =3,ErrorMessage ="Ingrese longitud entre 3 a 30 caracteres")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime LastBuy { get; set; }

    }
}