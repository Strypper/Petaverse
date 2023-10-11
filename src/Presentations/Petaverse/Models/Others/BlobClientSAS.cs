using System;
using System.ComponentModel;

namespace Petaverse.Models.Others
{
    public class BlobClientSAS
    {
        public Uri SASUri { get; set; }
        public string BlobUrl { get; set; }
    }
    public class PetShortSAS : BlobClientSAS
    {
        public int PetShortId { get; set; }
    }
}
