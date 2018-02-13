using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;

namespace WebcamSettings
{
    public class Webcam
    {
        public string Name { get; set; }
        public IMoniker Moniker { get; set; }
        public string UserName { get; set; }
    }
}
