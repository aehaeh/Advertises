using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class InnerCategoryViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن عنوان دسته بندی   ضروری  است ")]
        public string Title
        { set; get; }

        /*  public Category Category
           {
               set;
               get;
           }
           */
        public long CategoryId
        { set; get; }
        public List<Advertisement> Advertisements
        { get; set; }
    }
}
