using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADataTestVichara
{
    [Serializable]
    public class Ordenes
    {
        public string CustomerName { get; set; }
        public string VendorName { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int Quantities { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
