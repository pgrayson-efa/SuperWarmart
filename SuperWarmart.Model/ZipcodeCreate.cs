using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class ZipCodeCreate
    {
        public int ZipCodeId { get; set; }
        public int StateId { get; set; }
        public string VerifiedZipCode { get; set; }
        public string City { get; set; }
    }
}
