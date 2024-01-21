using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FriBird.Tool
{
    public class Constants
    {
        public static readonly string BASE_IMAGE_DIR = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Images";
        public static readonly int SIRKA_PREKAZKY = 50;
        public static readonly int DLZKA_PREKAZKY = 240;

        //private static final int POHYB_PREKAZKY = 10;
        public static readonly int POHYB_PREKAZKY = 2;
        /**
         * Určuje šírku medzi prekážkami v x osi
         */
        public static readonly int SIRKA_MEDZI_PREKAZKAMI = 300;
        /**
         * Určuje šírku medzi prekážkami v y osi
         */
        public static readonly int VYSKA_MEDZI_PREKAZKAMI = 140; //140
    }

}
