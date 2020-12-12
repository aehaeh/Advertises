using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        
        [Required(ErrorMessage = "وارد کردن عنوان ضروری  است ")]        
        public string Title { set; get; }


        public ICollection<Advertisement> advertisements
        { set; get; }
        public DateTime? UpdatedDate { set; get; }

        public DateTime CreateDate { set; get; }
    }
}
