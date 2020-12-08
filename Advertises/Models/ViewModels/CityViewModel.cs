using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class CityViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام شهر   ضروری  است ")]
        public string Name { set; get; }



        public bool IsActive
        { set; get; }
        public DateTime? UpdatedDate { set; get; }

        public DateTime CreateDate { set; get; }

        public List<Local> Locals { get; set; }
    }
}
