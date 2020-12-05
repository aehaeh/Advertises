using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime? UpdatedDate { set; get; }

        public DateTime CreateDate { set; get; }

    }
}
