using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class City : BaseEntity
    {
        public string Name { set; get; }



        public bool IsActive
        { set; get; }

        public List<Local> Locals { get; set; }


    }
}
