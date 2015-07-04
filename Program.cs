using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IrrlichtLime.Video;
using EasimerDRM;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EasimerDemoScene
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            string[] scArgs = Environment.GetCommandLineArgs();
            Mods.setContentFolder("./Content/");
            
            string MD5 = null;
            bool isConnected = Protection.isConnectedToInternet();
            try
            {
                MD5 = Protection.MD5Calc("drm.key");
            }
            catch (FileNotFoundException ex)
            {
                    string error = ex.ToString();
                    Logger.Log(error);
                    Environment.Exit(0);
            }
            
                if (MD5 == "33772fe62ad384eb9e215c02f9c338ee")
                {
                    if(isConnected)
                    {
                        Application.EnableVisualStyles();
                        Application.Run(new MenuScreen());
                    } 
                    else 
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
