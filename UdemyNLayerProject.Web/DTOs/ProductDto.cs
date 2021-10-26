using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="{0} alanı gereklidir")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} alanı 1'den byük olmalıdır.")]
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 1'den byük olmalıdır.")]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }

    }
}
