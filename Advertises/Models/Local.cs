using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Local
    {
        public string Name { set; get; }
        [Key]
        public long Id { set; get; }

        public DateTime CreateDate
        {
            set; get;
        }
        public bool IsActive
        {
            set;
            get;
        }

        public City City { get; set; }
        public long CityId { get; set; }
        public List<Advertisement> Advertisements
        {
            get;
            set;
        }
    }
}
