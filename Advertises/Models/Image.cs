using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Image :BaseEntity
    {
       
        public long AdvertismentId
        {
            set;
            get;
        }
        public byte[] File
        {
            set;get;
        }
        public Advertisement Advertisment
        {
            set;
            get;
        }
    }
}
