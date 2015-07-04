using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IrrlichtLime;
using IrrlichtLime.Core;
using IrrlichtLime.Scene;
using IrrlichtLime.Video;

using NAudio;
using NAudio.Wave;

namespace EasimerDemoScene
{
    /// <summary>
    /// Yodan
    /// </summary>
    class Waiter
    {
        /*static SceneNodeAnimator anim = Graphics.anim;
        static SceneManager smgr = Graphics.smgr;
        static IrrlichtDevice device = Graphics.device;

        public static void spawnWaiter()
        {
             anode = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/waiter.md2"));
            anode.Position = new Vector3Df(-1355, -211, -1420);
            anode.AnimationSpeed = 15;
            anode.SetMaterialFlag(MaterialFlag.Lighting, true);
            anode.GetMaterial(0).NormalizeNormals = true;
            anode.GetMaterial(0).Lighting = false;
            Waiter.Stand();
        }
        public static void Walk(Vector3Df from, Vector3Df to)
        {
            Scenes.changeWaiterAnimation(Waiter.anode, "walk");
            Scenes.moveFromTo(anim, smgr, from, to, anode, true);
        }
        /// <summary>
        /// A szörny megáll
        /// </summary>
        public static void Stand()
        {
            Vector3Df waiterpos = Waiter.anode.Position;
            Scenes.changeWaiterAnimation(Waiter.anode, "idle");
            Scenes.moveFromTo(anim, smgr, waiterpos, waiterpos, Waiter.anode, true);
        }*/


        
    }
}
