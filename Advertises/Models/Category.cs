using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Category
    {
        [Key]
        public long Id { set; get; }
        [Display(Name ="عنوان")]
        public string Title
        {
            set;
            get;
        }
        public DateTime CreateDate
        {
            set;
            get;
        }
        public DateTime? UpdatedDate
        {
            set;
            get;
        }
        public ICollection<Advertisement> advertisements
        {
            get; 
            set; 
        }

    }
}
