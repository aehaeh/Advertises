using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Image
    {
        public long Id
        {
            set;
            get;
        }
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
