using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class LocalViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام محل  ضروری  است ")]
        public string Name { set; get; }



        public bool IsActive
        { set; get; }
        [Required(ErrorMessage = "وارد کردن نام شهر  ضروری  است ")]
        public City City { get; set; }
        public long CityId { get; set; }
        public List<Advertisement> Advertisements
        { set; get; }
    }
}
