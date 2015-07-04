using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using IrrlichtLime;
using IrrlichtLime.Core;
using IrrlichtLime.Scene;
using IrrlichtLime.Video;
using IrrlichtLime.GUI;

using NAudio;
using NAudio.Wave;

namespace EasimerDemoScene
{
    public class Yodan
    {
        static SceneNodeAnimator anim = Graphics.anim;
        static SceneManager smgr = Graphics.smgr;
        static IrrlichtDevice device = Graphics.device;
        static VideoDriver driver = Graphics.driver;
        public static BoneSceneNode head;
        static bool performNope = true;
        public static System.Timers.Timer aTimer = new System.Timers.Timer();
        public static GUIFont font = device.GUIEnvironment.BuiltInFont;
        public static TextSceneNode yodanName;
        static AnimatedMeshSceneNode anode;

        
        public static void spawnYodan()
        {
            anode = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/yodan.mdl"));
            anode.Position = new Vector3Df(-1355, -211, -1410);
            anode.AnimationSpeed = 15;
            anode.SetMaterialFlag(MaterialFlag.Lighting, true);
            anode.GetMaterial(0).NormalizeNormals = true;
            anode.GetMaterial(0).Lighting = false;
            anode.SetTransitionTime(3);
            yodanName = smgr.AddTextSceneNode(font, "Yodan a Bérgyilkos <Level 90>", new Color(255, 0, 0), null, Yodan.anode.Position + new Vector3Df(0, 50, 0), 0);
            Yodan.Stand();
            aTimer.Elapsed += new ElapsedEventHandler(NameLoop);
            // Set the Interval to 0.1 seconds.
            aTimer.Interval = 100;
            aTimer.Enabled = true;
        }
        public static void Run(Vector3Df from, Vector3Df to)
        {
            Scenes.changeYodanAnimation(Yodan.anode, "run");
            Scenes.moveFromTo(anim, smgr, from, to, anode, true);
        }
        /// <summary>
        /// A szörny megáll
        /// </summary>
        public static void Stand()
        {
            Vector3Df yodanpos = Yodan.anode.Position;
            Scenes.changeYodanAnimation(Yodan.anode, "idle");
            Scenes.moveFromTo(anim, smgr, yodanpos, yodanpos, Yodan.anode, true);
        }

        public static void Wave()
        {
            Scenes.changeYodanAnimation(anode, "wave");
        }


        public static void Speak(string voiceFile)
        {
            Audio.playWave(voiceFile);
        }
        /// <summary>
        /// Integet egyet, köszön és úgyis marad.
        /// </summary>
        public static void WaveAndGreet()
        {
            Yodan.Stand();
                Yodan.Wave();
                Yodan.Speak("./Content/Sound/vo/yodan/yo_greetings.mp3");
        }

        public static void GoGhost()
        {
            anode.SetMaterialTexture(0, driver.GetTexture("./Content/2D/ghost.png"));
            anode.SetMaterialType(MaterialType.TransparentAddColor);
        }
        public static void GoNormal()
        {
            anode.SetMaterialTexture(0, driver.GetTexture("./Content/2D/yodan.png"));
            anode.SetMaterialType(MaterialType.Solid);
        }
        public static void NameLoop(object source, ElapsedEventArgs e)
        {
            yodanName.Position = anode.Position + new Vector3Df(0, 50, 0);
        }
    }
}
