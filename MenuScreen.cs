using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using IrrlichtLime.Video;
using NAudio.Wave;
using NAudio;

namespace EasimerDemoScene
{
    public partial class MenuScreen : Form
    {
        public static int screenWidth;
        public static int screenHeight;
        public MenuScreen()
        {
            InitializeComponent();
            this.Text = Property.modName + " Build " + Property.modVersion;
        }
        

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Random random = new Random();
            int bgID = random.Next(0, 4);
            string loadMap = mapBox.Text;
            string pak0Path = pak0Box.Text;
            string pak1Path = pak1Box.Text;
            string pak2Path = pak2Box.Text;
            DriverType drivertype = DriverType.OpenGL;
            bool isGL = driverGL.Checked;
            bool isDX = driverDX8.Checked;
            bool noMus = noMusic.Checked;
            bool isFSChecked = FSCB.Checked;
            if (bgID == 1 || bgID == 0)
            {
                this.BackgroundImage = EasimerDemoScene.Properties.Resources.bg2;
            }
            else if (bgID == 2)
            {
                this.BackgroundImage = EasimerDemoScene.Properties.Resources.bg4;
            }
            else if (bgID == 3 || bgID == 4)
            {
                this.BackgroundImage = EasimerDemoScene.Properties.Resources.bg5;
            }
            if (isGL)
            {
                drivertype = DriverType.OpenGL;
            }
            else if (isDX)
            {
                drivertype = DriverType.Direct3D8;
            }
            else
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Logger.Log("FATAL ERROR: Driver not found!");
                }
                Environment.Exit(0);
            }
            if (noMus)
            {
                //Semmi :D
            }
            else if (!noMus)
            {
                Audio.playWave("./Content/Music/" + Property.bgMusic);
            }
            Graphics.createScreen(Property.modName, Property.resolutionX, Property.resolutionY, drivertype, loadMap, pak0Path, pak1Path, pak2Path, isFSChecked);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
