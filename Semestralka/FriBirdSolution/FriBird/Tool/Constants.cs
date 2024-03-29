﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FriBird.Tool
{
    public enum GameStat
    {
        Start,
        Run,
        Lose,
    }

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

        public static readonly int POHYB = 1;

        public static readonly float ROTATION_SPEED = 2.5f;

        public static readonly int SIZE_OF_BIRD = 51;
    }

}
