using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasimerDemoScene
{
    class Mods
    {
        public static string defaultContentFolder = "./Content/";
        public static void setContentFolder(string modName)
        {
            defaultContentFolder = "./"+ modName +"/Content/";
        }
    }
}
