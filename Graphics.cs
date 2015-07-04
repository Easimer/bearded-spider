//Rendszer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
//3D
using IrrlichtLime;
using IrrlichtLime.Core;
using IrrlichtLime.Video;
using IrrlichtLime.Scene;
using IrrlichtLime.GUI;

namespace EasimerDemoScene
{
    class Graphics
    {
        #region Értékek
        public static int buildVersion = 1400;
        protected static AnimatedMeshSceneNode node2 = null;
        SceneNode node = null;
        static SceneNode lightNode;
        public static Shadow shadows = null;
        static SceneNode lightMovementHelperNode;
        public static AnimatedMeshSceneNode anode2;
        public static AnimatedMeshSceneNode anode;
        public static AnimatedMeshSceneNode anode3;
        public static SceneManager smgr;
        public static SceneNodeAnimator anim;
        public static IrrlichtDevice device;
        public static CameraSceneNode camera;
        public static VideoDriver driver;
        //public static GUIImage hurtOverlay;
        public static bool AutoAttack = false;
        static bool IsRPG;
        public static bool IsRun = true;
        public static int currentWeapon = 1;
        // 1 = Kések
        // 2 = Nyílpuska
        public static bool IsEtlapPickedUp = false;
        public static bool Quest1Done;
        public static bool weaponHolster = true;
        
        
        static System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        #endregion
        static int IDFlag_IsPickable = 1 << 0;

        public static void Delay(uint msec)
        {
            uint time = device.Timer.RealTime;
            do 
            { 
                //nothin'
            } 
            while (device.Timer.RealTime < time + msec);
        }

        public static void takeScreenshot(IrrlichtDevice device)
        {
            VideoDriver driver = device.VideoDriver;
            Image screenshot = driver.CreateScreenShot();
            string filename = "screenshot_" + device.Timer.RealTime + ".png";
            driver.WriteImage(screenshot, filename);
        }
        /// <summary>
        /// Létrehoz egy sizex*sizey méretű ablakot, windowCaption címmel és deviceType renderelési eszközzel.
        /// </summary>
        /// <param name="windowCaption">Ablak címe</param>
        /// <param name="sizex">Ablak szélessége</param>
        /// <param name="sizey">Ablak magassága</param>
        /// <param name="deviceType">A render eszköz típusa ("DriverType.OpenGL;" (OpenGL) vagy "DriverType.Direct3D8;"/"DriverType.Direct3D9;" (DirectX))</param>
        /// <param name="mapName">Betöltendő pálya neve a kiterjesztés nélkül (pl. "devmap")</param>
        /// <param name="pak0">A pak0 fájl neve (pl. "pak0" vagy "pack1")</param>
        /// <param name="pak1">A pak1 fájl neve (pl. "pak1" vagy "pack4")</param>
        /// <param name="pak2">A pak2 fájl neve (pl. "pak2" vagy "pack2")</param>
        public static void createScreen(string windowCaption, int sizex, int sizey, DriverType deviceType, string mapName, string pak0, string pak1, string pak2, bool isFullScreen)
        {

            //Ablakot megjeleníteni
            if (isFullScreen == true)
            {
                device = IrrlichtDevice.CreateDevice(deviceType, new Dimension2Di(sizex, sizey), 32, true, false, true);
            }
            else
            {
                device = IrrlichtDevice.CreateDevice(deviceType, new Dimension2Di(sizex, sizey), 32, false, false, true);
            }
            if (device == null)
                return;
            
            AnimatedMesh q3levelmesh = null;
            device.OnEvent += new IrrlichtDevice.EventHandler(device_OnEvent);
            device.SetWindowCaption(Property.modName + " Build " + Property.modVersion);
            driver = device.VideoDriver;
            smgr = device.SceneManager;


            GUIEnvironment gui = device.GUIEnvironment;
            //fadein
            GUIInOutFader fader = device.GUIEnvironment.AddInOutFader();
            fader.SetColor(new Color(0, 0, 0, 255));
            fader.FadeIn(2000);
            //hurtOverlay = device.GUIEnvironment.AddImage(driver.GetTexture("./Content/2D/Overlays/hurt.png"), new Vector2Di(0, 0));
            //hurtOverlay.Visible = false;
            GUIImage copyrightScreen = device.GUIEnvironment.AddImage(driver.GetTexture("./Content/2D/exit.tga"), new Vector2Di(0, 0));
            float guiScalex = sizex / 800;
            float guiScaley = sizey / 600;
            copyrightScreen.Visible = false;
            copyrightScreen.ScaleImage = true;
            copyrightScreen.SetMaxSize(new Dimension2Di(sizex, sizey));
            copyrightScreen.SetMinSize(new Dimension2Di(sizex, sizey));
            //Betölteni a mapot
            try
            {
                device.FileSystem.AddFileArchive("./Content/PK3/" + pak0 + ".edsf");
            }
            catch (Exception ex)
            {
                Logger.Log("pak0 fajl betoltese sikertelen vagy nem talalhato, a jatek nem tud betoltodni");
                string error = ex.ToString();
                    Logger.Log(error);
                Environment.Exit(0);
            }
            try
            {
                device.FileSystem.AddFileArchive("./Content/PK3/" + pak1 + ".edsf");
            }
            catch (Exception ex)
            {
                Logger.Log("pak1 fajl betoltese sikertelen vagy nem talalhato, ignoralva");
                string error = ex.ToString();
                    Logger.Log(error);
            }
            try
            {
                device.FileSystem.AddFileArchive("./Content/PK3/" + pak2 + ".edsf");
            }
            catch (Exception ex)
            {
                Logger.Log("pak2 fajl betoltese sikertelen vagy nem talalhato, ignoralva");
                string error = ex.ToString();
                    Logger.Log(error);
            }
            try
            {
                q3levelmesh = smgr.GetMesh(mapName + ".bsp");
            }
            catch (Exception ex)
            {
                Logger.Log("Palya betoltese sikertelen vagy nem talalhato, a jatek nem tud betoltodni");
                string error = ex.ToString();
                Logger.Log(error);
                Environment.Exit(0);
            }
            MeshSceneNode q3node = null;
                q3node = smgr.AddOctreeSceneNode(q3levelmesh.GetMesh(0), null, IDFlag_IsPickable);
                q3node.Position = new Vector3Df(-1350, -130, -1400);
            SceneNode node = null;
            if (mapName == "rpg")
            {
                IsRPG = true;
            }
            //LightSceneNode light = smgr.AddLightSceneNode(q3node, new Vector3Df(-1319, -118, -1410), new Color(255, 255, 255), 600.0, 10);
            //Half-Life Headcrab
            AnimatedMeshSceneNode anode3 = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/headcrab.mdl"));
            if (IsRPG)
            {
                anode3.Position = new Vector3Df(-1212, -180, -1346);
                Audio.playWave("./Content/Music/rpg.mp3");
            }
            else
            {
                anode3.Position = new Vector3Df(-1372.951f, -145.9882f, -1319.71f);
            }
            anode3.Rotation = new Vector3Df(0, 0, 0);
            anode3.AnimationSpeed = 1;
            Scenes.changeAnimation(anode3, 1, 31);
            anode3.SetMaterialFlag(MaterialFlag.Lighting, true);
            anode3.GetMaterial(0).NormalizeNormals = true;
            anode3.GetMaterial(0).Lighting = false;
            //Yodan
            anode2 = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/yodan.mdl"));
            anode2.Position = new Vector3Df(-1355, -200, -1410);
            anode2.AnimationSpeed = 15;
            anode2.SetMaterialFlag(MaterialFlag.Lighting, true);
            anode2.GetMaterial(0).NormalizeNormals = true;
            anode2.GetMaterial(0).Lighting = false;
            anode2.SetTransitionTime(3);
   			Scenes.changeYodanAnimation(anode2, "idle");
            //SkyBox
            SceneNode skybox = smgr.AddSkyBoxSceneNode("./Contents/2D/Skybox/mountains_up.jpg", "./Contents/2D/Skybox/mountains_dn.jpg", "./Contents/2D/Skybox/mountains_lf.jpg", "./Contents/2D/Skybox/mountains_rt.jpg", "./Contents/2D/Skybox/mountains_ft.jpg", "./Contents/2D/Skybox/mountains_bk.jpg");
            skybox.Visible = true;
            //FPS kamera hozzáadása
            camera = smgr.AddCameraSceneNodeFPS();
            camera.Position = new Vector3Df(-1625.723f, -145.9937f, -1532.087f);
            camera.Target = new Vector3Df(-1491.555f, -1434.106f, -1368.737f);
            //fegyver
            AnimatedMesh weaponmesh = smgr.GetMesh("./Content/3D/blades.mdl");
            AnimatedMeshSceneNode weapon = smgr.AddAnimatedMeshSceneNode(weaponmesh, camera, 30);
            weapon.Scale = new Vector3Df(0.5f, 0.5f, 0.5f);
            weapon.Position = new Vector3Df(0, 0, 15);
            weapon.Rotation = new Vector3Df(0, -90, 0);
            Scenes.changeAnimation(weapon, 1, 1);
            weapon.Visible = true;
            //fizika
            TriangleSelector selector;
            selector = smgr.CreateOctreeTriangleSelector(q3levelmesh.GetMesh(0), q3node, 128);
            q3node.TriangleSelector = selector;
            anim = smgr.CreateCollisionResponseAnimator(selector, camera, new Vector3Df(30, 50, 30), new Vector3Df(0, -10, 0), new Vector3Df(0, 30, 0));
            //Overlay
            GUIImage overlay = device.GUIEnvironment.AddImage(driver.GetTexture("./Content/2D/Overlays/vignette.png"), new Vector2Di(0, 0));
            overlay.ScaleImage = true;
            overlay.SetMaxSize(new Dimension2Di(sizex, sizey));
            overlay.SetMinSize(new Dimension2Di(sizex, sizey));
            selector.Drop();
            camera.AddAnimator(anim);
            anim.Drop();
            // fény
            lightMovementHelperNode = smgr.AddEmptySceneNode();

            q3node = smgr.AddSphereSceneNode(2, 6, lightMovementHelperNode, -1, new Vector3Df(15, -10, 15));
            q3node.SetMaterialFlag(MaterialFlag.Lighting, false);

            lightNode = q3node;

            //A Portré
            anode = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/portrait.mdl"));
            anode.Position = new Vector3Df(-1177.601f, -137.975f, -1238.015f);
            anode.Rotation = new Vector3Df(0,0,0);
            anode.Scale = new Vector3Df(3);
            anode.AnimationSpeed = 1500;
            anode.SetMaterialFlag(MaterialFlag.Lighting, true);
            anode.GetMaterial(0).NormalizeNormals = true;
            anode.GetMaterial(0).Lighting = false;

            AnimatedMeshSceneNode anode4 = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/waiter.mdl"));
            anode4.Position = new Vector3Df(-1130, -375, -1724);
            anode4.Rotation = new Vector3Df(0, -90, 0);
            anode4.Scale = new Vector3Df(2, 2, 2);
            anode4.SetMaterialFlag(MaterialFlag.Lighting, false);
            Scenes.changeAnimation(anode4, 0, 1);
            

            //Egér elrejtése
            device.CursorControl.Visible = false;
            GUIFont font = device.GUIEnvironment.BuiltInFont;
            SceneCollisionManager collMan = smgr.SceneCollisionManager;
            TextSceneNode headcrabName = smgr.AddTextSceneNode(font, "Yodan Lebegö Headcrab-je <Level 10>", new Color(255, 255, 0), null, anode3.Position + new Vector3Df(0, 25, 0), 0);
            TextSceneNode waiterName = smgr.AddTextSceneNode(font, "John <Level 15>", new Color(0, 255, 0), null, anode4.Position + new Vector3Df(0, 125, 0), 0);
            uint then = device.Timer.Time;
            float MOVEMENT_SPEED = 100.0f;

            //Energiagömb
            /*AnimatedMeshSceneNode anode5 = smgr.AddAnimatedMeshSceneNode(smgr.GetMesh("./Content/3D/core.mdl"));
            anode5.Position = new Vector3Df(-1355, 0, -1410);
            Scenes.changeAnimation(anode5, 0, 90);
            anode5.Scale = new Vector3Df(2.0f);
            Line3Df coreray = new Line3Df(-1355, 0, -1410, -1355, -500, -1410);
            driver.SetMaterial(anode5.GetMaterial(1));
            driver.SetTransform(TransformationState.World, Matrix.Identity);
            driver.Draw3DLine(coreray, new Color(255,0,0));*/
            
            GUIImage bartenderForm = device.GUIEnvironment.AddImage(driver.GetTexture("./Content/2D/bartender.png"), new Vector2Di(10, 10));
            bartenderForm.ScaleImage = true;
            bartenderForm.Visible = false;
            bartenderForm.SetMinSize(new Dimension2Di(sizex - 10, sizey - 10));
            bartenderForm.SetMaxSize(new Dimension2Di(sizex - 10, sizey - 10));
            bool BartenderFormIsOpen = false;
            GUIImage ActionBar = device.GUIEnvironment.AddImage(driver.GetTexture("./Content/2D/Hud/Actionbar.tga"), new Vector2Di(0, 600 - 128));
            //330, 110  790, 120
            Recti expbarrect = new Recti();
            ExperienceBar expbar = new ExperienceBar(gui, expbarrect,0, ActionBar);
            expbar.SetProgress(0);
            expbar.SetColors(new Color(255, 255, 0), new Color(255, 255, 255));
            expbar.AddBorder(5, new Color(0, 0, 0));
            expbar.SetMinSize(new Dimension2Di(128, 64));
            expbar.SetMaxSize(new Dimension2Di(128, 64));
            //Mi minek a része
            q3node.AddChild(anode);
            q3node.AddChild(anode2);
            q3node.AddChild(anode3);
            q3node.AddChild(anode4);
            TextSceneNode yodanName = smgr.AddTextSceneNode(font, "Yodan a Bérgyilkos <Level 90>", new Color(255, 0, 0), null, anode2.Position + new Vector3Df(0, 50, 0), 0);
            while (device.Run())
            {
                driver.BeginScene(true, true, new Color(135, 206, 235));
                
                smgr.DrawAll();
                gui.DrawAll();
                string printDate = dateTime.ToShortTimeString();
                uint now = device.Timer.Time;
                float frameDeltaTime = (float)(now - then) / 1000.0f;
                then = now;
                Vector3Df nodePosition = camera.Position;
                if (font != null)
                {
                    /*font.Draw("Build " + Property.modVersion, 5, 5, new Color(0, 0, 255));
                    font.Draw("pos= " + camera.Position, 5, 578 - 16, new Color(0, 0, 255));
                    font.Draw("tar= " + camera.Target, 5, 594 - 16, new Color(0, 0, 255));*/
                    font.Draw(Player.Experience(), new Vector2Di(505, 582), new Color(0,0,0));
                }
                if (camera.Position.Z >= 10000)
                {
                    font.Draw("Kiestél a Világból!", new Vector2Di(400, 300), new Color (0, 0, 0));
                    camera.Position = anode.Position;
                }

                if (Quest1Done)
                {
                    yodanName.SetTextColor(new Color(255, 255, 0));
                }

                if (IsKeyDown(KeyCode.Space))
                {
                    nodePosition.Y += MOVEMENT_SPEED * frameDeltaTime;
                }
                else if (IsKeyDown(KeyCode.LControl))
                {
                    nodePosition.Y -= MOVEMENT_SPEED * frameDeltaTime;
                }
                if (IsKeyDown(KeyCode.LShift))
                {
                    MOVEMENT_SPEED = 200.0f;
                }
                else
                {
                    MOVEMENT_SPEED = 100.0f;
                }

                if (IsKeyDown(KeyCode.Esc))
                {
                    copyrightScreen.Visible = true;
                }
                if (IsKeyDown(KeyCode.KeyM)) 
                {
                    //Yodan.Run(new Vector3Df(-1642, -172, -1421), new Vector3Df(-1053, -167, -1416));
                }
                if (IsKeyDown(KeyCode.KeyB))
                {
                   // Yodan.Wave();
                   
                   Scripting.RunScript(Scripting.LoadScript());
                }
                if (IsKeyDown(KeyCode.KeyV))
                {
                    //Yodan.Speak("./Content/Sound/vo/yodan/yo_20ft.mp3");
                }
                else if (IsKeyDown(KeyCode.KeyN))
                {
                    //Yodan.Stand();
                }
                else if (IsKeyDown(KeyCode.KeyC))
                {
                    //Yodan.WaveAndGreet();
                }
                //Actionbar START

                //Auto-Attack
                if (IsKeyDown(KeyCode.Key1))
                {
                    if (!AutoAttack)
                    {
                        Delay(100);
                        AutoAttack = true;
                        if (currentWeapon == 1)
                        {
                            Scenes.changeAnimation(weapon, 11 + 24 + 25, 11 + 24 + 25 + 31 + 30);
                        }
                        else if (currentWeapon == 2)
                        {
                            Scenes.changeAnimation(weapon, 91 + 31 + 81 + 31, 91 + 31 + 81 + 31+90);
                        }
                    }
                    else if (AutoAttack)
                    {
                        Delay(100);
                        AutoAttack = false;
                        if (currentWeapon == 1)
                        {
                            Scenes.changeAnimation(weapon, 1, 1);
                        }
                        else if (currentWeapon == 2)
                        {
                            Scenes.changeAnimation(weapon, 1, 90);
                        }

                    }
                }
                //Blades
                if (IsKeyDown(KeyCode.Key2))
                 {
                     AnimatedMesh bladesmesh = smgr.GetMesh("./Content/3D/blades.mdl");
                     weapon.Mesh = bladesmesh;
                     weapon.Scale = new Vector3Df(0.5f, 0.5f, 0.5f);
                     weapon.Position = new Vector3Df(0, 0, 15);
                     weapon.Rotation = new Vector3Df(0, -90, 0);
                     Scenes.changeAnimation(weapon, 1, 1);
                     currentWeapon = 1;
                 }
                 //Crossbow
                 if (IsKeyDown(KeyCode.Key3))
                 {
                     AnimatedMesh crossbowmesh = smgr.GetMesh("./Content/3D/crossbow.mdl");
                     weapon.Mesh = crossbowmesh;
                     Scenes.changeAnimation(weapon, 1, 90);
                     weapon.Scale = new Vector3Df(3.0f, 3.0f, 3.0f);
                     currentWeapon = 2;
                    
                 }
                 if (IsKeyDown(KeyCode.Key4))
                 {
                     if (IsEtlapPickedUp)
                     {
                         bartenderForm.Visible = true;
                         BartenderFormIsOpen = true;
                         Audio.playWave("./Content/sound/paper_pickup.mp3");
                     }

                 }


                //Actionbar END
                
                //elteszi/előveszi a fegyvert
                if(IsKeyDown(KeyCode.Tab))
                {
                	if(weaponHolster)
                	{
                	weapon.Visible = false;
                	Audio.playWave("./Content/sound/weapon.mp3");
                	weaponHolster = false;
                	} 
                	else
                	{
                	weapon.Visible = true;
                	Audio.playWave("./Content/sound/weapon.mp3");
                	weaponHolster = true;
                	}
                }
                if (IsKeyDown(KeyCode.MouseLButton))
                {
                    AutoAttack = true;
                    if (currentWeapon == 1)
                    {
                        Scenes.changeAnimation(weapon, 11 + 24 + 25, 11 + 24 + 25 + 31 + 30);
                    }
                    else if (currentWeapon == 2)
                    {
                        Scenes.changeAnimation(weapon, 91 + 31 + 81 + 31, 91 + 31 + 81 + 31 + 90);
                    }
                }
                else if (!IsKeyDown(KeyCode.MouseLButton))
                {
                    AutoAttack = false;
                    if (currentWeapon == 1)
                    {
                        Scenes.changeAnimation(weapon, 1, 1);
                    }
                    else if (currentWeapon == 2)
                    {
                        Scenes.changeAnimation(weapon, 1, 90);
                    }
                }

                if (IsKeyDown(KeyCode.KeyX))
                {
                    Texture yodanMissing = driver.GetTexture("./Content/2D/yodanmissing.tga");
                    Dimension2Di yodanMisSiz = yodanMissing.Size;
                    yodanMisSiz = anode.GetMaterial(0).GetTexture(0).Size;
                    anode.SetMaterialTexture(0, yodanMissing);
                }
                if (IsKeyDown(KeyCode.KeyE))
                {
                    //Bartender Johh On-Use
                    Vector3Df camtarget = camera.Target;
                    if (!BartenderFormIsOpen)
                    {
                        if (new Vector3Df(727, 221, -986) <= camtarget)
                        {
                            if (new Vector3Df(763, 276, -2329) >= camtarget)
                            {
                                if (camtarget > new Vector3Df(184, -1843, -1255))
                                {
                                    if (camtarget > new Vector3Df(138, -1837, -2318))
                                    {
                                        bartenderForm.Visible = true;
                                        BartenderFormIsOpen = true;
                                        if (!IsEtlapPickedUp)
                                        {
                                            ActionBar.Image = driver.GetTexture("./Content/2D/Hud/Actionbar_etlap.tga");
                                            Audio.playWave("./Content/sound/vo/waiter_john/teatime.mp3");
                                        }
                                        IsEtlapPickedUp = true;
                                        Audio.playWave("./Content/sound/paper_pickup.mp3");
                                    }
                                }
                            }
                        }
                    }
                    else if (BartenderFormIsOpen)
                    {
                        bartenderForm.Visible = false;
                        BartenderFormIsOpen = false;
                        Audio.playWave("./Content/sound/paper_pickup.mp3");
                    }
                }
                
                if (IsKeyDown(KeyCode.KeyK))
                {
                    //Yodan.GoGhost();
                }
                if (IsKeyDown(KeyCode.KeyJ))
                {
                    //Yodan.GoNormal();
                }
                if (IsKeyDown(KeyCode.KeyL))
                {
                    
                }
                if (IsKeyDown(KeyCode.F7))
                {
                    Delay(500);
                    takeScreenshot(device);
                }
                if (IsKeyDown(KeyCode.F9))
                {
                    Delay(500);
                    string campos = camera.Position.ToString();
                    Logger.Log("position:" + campos);
                    string camtar = camera.Target.ToString();
                    Logger.Log("target: " + camtar);
                }
                if (IsKeyDown(KeyCode.LShift))
                {
                    if (IsKeyDown(KeyCode.KeyY))
                    {
                        Environment.Exit(0);
                    } else if (IsKeyDown(KeyCode.KeyN))
                    {
                        copyrightScreen.Visible = false;
                    }
                }

                camera.Position = nodePosition;
                driver.EndScene();
            }
            device.Drop();
        }

        static Dictionary<KeyCode, bool> KeyIsDown = new Dictionary<KeyCode, bool>();

        static bool device_OnEvent(Event e)
        {
            if (e.Type == EventType.Key)
            {
                if (KeyIsDown.ContainsKey(e.Key.Key))
                    KeyIsDown[e.Key.Key] = e.Key.PressedDown;
                else
                    KeyIsDown.Add(e.Key.Key, e.Key.PressedDown);
            }

            return false;
        }

        /// <summary>
        /// Érzékeli ha a egy billentyű le van nyomva
        /// </summary>
        /// <param name="keyCode">A billentyű neve</param>
        /// <returns>Ha a billentyű le van nyomva akkor true, ha nem akkor false</returns>
        static bool IsKeyDown(KeyCode keyCode)
        {
            
            return KeyIsDown.ContainsKey(keyCode) ? KeyIsDown[keyCode] : false;
        }

        
        
    }
}
