using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_DannyMarceloDávilaBarrancos.Models
{
    public class Lucky
    {
        [Key]
        public string SuerteID { get; set; }
        [Display(Name = "Suerte: ")]
        public string Detalle { get; set; }
        [Display(Name = "Foto de la Suerte:")]
        [Required]
        [Url]
        public string Imagen { get; set; }

    }
}
