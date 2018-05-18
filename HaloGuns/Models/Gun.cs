using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaloGuns.Models
{
    public class Gun
    {
        public long ID { get; set; }
        public string name { get; set; } // Battle Rifle / Assault Rifle / Magnum / Plasma Pistol etc 
        public string faction { get; set; } // UNSC / Flood / Covenant / Sentinal / Promethians 
        public string race { get; set; } // race = [primary] species 
        // public double accuracy { get; set; } 
        // public string range { get; set; } // long / short / medium 
        public string type { get; set; } // fully automatic / sidearm / heavy etc 
        public string technology { get; set; } // Plasma / Mechanical / Forerunner 
    }
}