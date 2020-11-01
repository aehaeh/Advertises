using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Advertisement
    {
        [Key]
        public long Id { set; get; }
        public string Title
        {
            set;
            get;
        }
        public string Description
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
        public decimal price
        {
            get;
            set;

        }

        public Category Category
        {
            set;
            get;
        }
        public long CategoryId
        {
            set;
            get;
        }

        public bool IsActive
        {
            set;
            get;

        }

    }


}
