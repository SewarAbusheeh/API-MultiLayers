using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahelef.Core.DTO
{

    public class Main
    {
        public string Temp { get; set; }
        public string humidity { get; set; }
    }
    public class Wind
    {
        public string speed { get; set; }
    }
    public class Weather
    {
        public Main main { get; set; }
        public Wind wind { get; set; }
        public string name { get; set; }
        public string timeZone { get; set; }
    }

}
