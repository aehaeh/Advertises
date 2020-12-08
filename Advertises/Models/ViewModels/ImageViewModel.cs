using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class ImageViewModel
    {
        public long Id { get; set; }
        public long AdvertismentId
        { set; get; }
        public byte[] File
        { set; get; }
        public Advertisement Advertisment
        { set; get; }
        public DateTime? UpdatedDate { set; get; }

        public DateTime CreateDate { set; get; }
    }
}

