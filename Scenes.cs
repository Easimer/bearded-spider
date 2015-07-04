using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using IrrlichtLime;
using IrrlichtLime.Core;
using IrrlichtLime.Scene;
using IrrlichtLime.GUI;
using IrrlichtLime.IO;
using IrrlichtLime.Video;

namespace EasimerDemoScene
{
    class Scenes
    {
        public static bool isAtTo;
        /// <summary>
        /// Elmozdítani a modellt A pontból B pontba.
        /// </summary>
        /// <param name="anim">SceneNodeAnimator</param>
        /// <param name="smgr">SceneManager</param>
        /// <param name="from">A pont</param>
        /// <param name="to">B pont</param>
        /// <param name="node">Mozgatni kívánt modell</param>
        /// <param name="loop">Végtelen ismétlés?</param>
        public static bool moveFromTo(SceneNodeAnimator anim, SceneManager smgr, Vector3Df from, Vector3Df to, SceneNode node, bool loop)
        {
            isAtTo = false;
            anim = smgr.CreateFlyStraightAnimator(from, to, 3.5f, loop);
            node.AddAnimator(anim);
            if (node.Position == to)
            {
                isAtTo = true;
            }
            else
            {
                isAtTo = false;
            }
            return isAtTo;
        }

        /// <summary>
        /// Megváltoztatja egy AnimatedMeshSceneNode animációját
        /// </summary>
        /// <param name="node">AnimatedMeshSceneNode</param>
        /// <param name="from">Kezdési frame</param>
        /// <param name="to">Utolsó frame</param>
        public static void changeAnimation(AnimatedMeshSceneNode node, int from, int to)
        {
            node.SetFrameLoop(from, to);
        }
        /// <summary>
        /// A Yodan modellhez állít be animációt
        /// </summary>
        /// <param name="node">A Yodan modell azonosítója</param>
        /// <param name="animName">Animáció neve</param>
        /// Animációk:
        ///  "idle" - egy helyben áll
        ///  "run"  - fut
        ///  "wave" - integet
        ///  "asleep" - elalszik
        public static void changeYodanAnimation(AnimatedMeshSceneNode node, string animName)
        {
            if (animName == "idle")
            {
                Scenes.changeAnimation(node, 32, 32+41);
            }
            else if (animName == "run")
            {
                Scenes.changeAnimation(node, 104, 127);
            }
            else if (animName == "asleep")
            {
                Scenes.changeAnimation(node, 567, 594);
            }
            else if (animName == "wave")
            {
                Scenes.changeAnimation(node, 594, 594);
            }
            else
            {
                    Logger.Log("Invalid Yodan animation name");
            }


        }
        /// <summary>
        /// A Pincér modellhez állít be animációt
        /// </summary>
        /// <param name="node">A Picér modell azonosítója</param>
        /// <param name="animName">Animáció neve</param>
        /// Animációk:
        /// "idle" - Áll egy helyben
        /// "walk" - Sétál
        public static void changeWaiterAnimation(AnimatedMeshSceneNode node, string animName)
        {
            if (animName == "idle")
            {
                Scenes.changeAnimation(node, 1, 1);
            }
            else if (animName == "walk")
            {
                Scenes.changeAnimation(node, 2, 4);
            }
            else
            {
                    Logger.Log("Invalid Waiter animation name");
            }


        }
        /// <summary>
        /// Beszél az npc
        /// </summary>
        /// <param name="voiceFile">Hangfájl</param>
        public static void Speak(string voiceFile)
        {
            Audio.playWave(voiceFile);
        }
    }
}
