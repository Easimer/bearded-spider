using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace EasimerDemoScene
{
    class Player
    {
        /// <summary>
        /// A szintlépéshez szükséges tapasztalatpontok
        /// 1. szint: 10 exp
        /// 2. szint: 20 exp
        /// 5. szint: 200 exp
        /// 10. szint: 10000 exp 
        /// stb.
        /// </summary>
        static int[] levelReq = {10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000};

        public static int Level()
        {
            int level2 = -1;
            string level;
            StreamReader saveFileReader = new StreamReader("./Content/Saves/save_001.erps");
            string saveFile = saveFileReader.ReadToEnd();
            saveFileReader.Close();
            StringBuilder output = new StringBuilder();
            using(XmlReader reader = XmlReader.Create(new StringReader(saveFile)))
            {
                reader.ReadToFollowing("level");
                reader.MoveToFirstAttribute();
                level = reader.Value;
            }
            if (level == "1")
            {
                level2 = 1;
            }
            else if (level == "2")
            {
                level2 = 2;
            }
            else if (level == "3")
            {
                level2 = 3;
            }
            else if (level == "4")
            {
                level2 = 4;
            }
            else if (level == "5")
            {
                level2 = 5;
            }
            else if (level == "6")
            {
                level2 = 6;
            }
            else if (level == "7")
            {
                level2 = 7;
            }
            else if (level == "8")
            {
                level2 = 8;
            }
            else if (level == "9")
            {
                level2 = 9;
            }
            else if (level == "10")
            {
                level2 = 10;
            }
            else
            {
                level2 = -1;
            }
            return level2;
        }
        public static string Experience()
        {
            string experience;
            StreamReader saveFileReader = new StreamReader("./Content/Saves/save_001.erps");
            string saveFile = saveFileReader.ReadToEnd();
            saveFileReader.Close();
            StringBuilder output = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(new StringReader(saveFile)))
            {
                reader.ReadToFollowing("experience");
                reader.MoveToFirstAttribute();
                experience = reader.Value;
            }
            int level = Player.Level();
            int nextLevel = level + 1;
            int expTilNextLevel = levelReq[nextLevel];

            return "Level " + level + " - " + "A következö szint a " + nextLevel + "., aminek a követelménye " + expTilNextLevel + " tapasztalatpont.";
        }
        public static string PlayerName()
        {
            string playerName;
            StreamReader saveFileReader = new StreamReader("./Content/Saves/save_001.erps");
            string saveFile = saveFileReader.ReadToEnd();
            saveFileReader.Close();
            StringBuilder output = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(new StringReader(saveFile)))
            {
                reader.ReadToFollowing("player");
                reader.MoveToFirstAttribute();
                playerName = reader.Value;
            }
            return playerName;
        }


        public static void LevelUp(int saveID)
        {
            string saveFile = "./Content/Saves/save_" + saveID + ".erps";
        }
    }
}
