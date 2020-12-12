using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Category : BaseEntity
    {
      
        //[Display(Name ="عنوان")]

            
        public string Title{ set; get; }


        public ICollection<Advertisement> advertisements
        { set; get; }

    }
}
