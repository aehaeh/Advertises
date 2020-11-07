using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class InnerCategory
    {
        [Key]
        public long Id { set; get; }

        public string Title
        {
            set;
            get;
        }
      
        /*  public Category Category
           {
               set;
               get;
           }
           */
        public long CategoryId
            {
            set;
            get;
            }
        public List<Advertisement> Advertisements
        {
            get;
            set;
        }

    }
}
