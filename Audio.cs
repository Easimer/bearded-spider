using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NAudio;
using NAudio.Wave;

namespace EasimerDemoScene
{
    class Audio
    {
        static IWavePlayer thread;
        static WaveStream stream;
        static WaveChannel32 volumeStream;
        static bool paused = true;
        /// <summary>
        /// Lejátszik egy .mp3 fájlt
        /// </summary>
        /// <param name="audioFile">.mp3 fájl</param>
        public static void playWave(string audioFile)
        {
            thread = new WaveOut();
            stream = CreateInputStream(audioFile);
            thread.Init(stream);
            thread.Play();
        }


        /// <summary>
        /// Betölti az mp3 fájlt
        /// </summary>
        /// <param name="fileName">mp3 fájlnév</param>
        /// <returns>Audió stream</returns>
        static private WaveStream CreateInputStream(string fileName)
        {
            WaveChannel32 inputStream;
            if (fileName.EndsWith(".mp3"))
            {
                WaveStream mp3Reader = new Mp3FileReader(fileName); 
                inputStream = new WaveChannel32(mp3Reader);
            }
            else
            {
                throw new InvalidOperationException("Ervenytelen fajl");
            }
            volumeStream = inputStream;
            paused = false;
            return volumeStream;
        }
        /// <summary>
        /// Lezárja az audió streamet
        /// </summary>
        static public void CloseWaveOut()
        {
            if (thread != null)
            {
                thread.Stop();
            }
            if (stream != null)
            {
                // this one really closes the file and ACM conversion
                volumeStream.Close();
                volumeStream = null;
                // this one does the metering stream
                stream.Close();
                stream = null;
            }
            if (thread != null)
            {
                thread.Dispose();
                thread = null;
            }
        }
        /// <summary>
        /// Szünetelteti a zenét
        /// </summary>
        static public void PauseMusic()
        {
            if (!paused)
            {
                try
                {
                    thread.Pause();
                    paused = true;
                }
                catch(Exception ex)
                {
                    string error = ex.ToString();
                    Logger.Log(error);
                    paused = false;
                }
            }
            else
            {
                Logger.Log("A zene mar megvan allitva.");
            }
        }

        static public void ResumeMusic()
        {
            if (paused)
            {
                thread.Play();
                paused = false;
            }
            else 
            {
                Logger.Log("A zenet nem folytathatom mivel nincs is megallitva.");
            }
        }

    }
}
