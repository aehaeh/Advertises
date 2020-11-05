using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class City
    {
        public string Name { set; get; }
        [Key]
        public long Id { set; get; }
       
        public DateTime CreateDate
        {
            set;get;
        }
        public bool IsActive
        {
            set;
            get;

        }
        public Local local
        {
            set;
            get;
        }
             
             

        public long localId { set; get; }
    }
}
