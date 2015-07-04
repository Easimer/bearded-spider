using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasimerDemoScene
{
    class Math
    {
        /// <summary>
        /// Összead két számot
        /// </summary>
        /// <param name="a">Első szám</param>
        /// <param name="b">Második szám</param>
        /// <returns>Eredmény</returns>
        public static int Osszeadas(int a, int b)
        {
            int c = a + b;
            return c;
        }
        /// <summary>
        /// Kivonja az egyik számot a másikból.
        /// </summary>
        /// <param name="a">Első szám</param>
        /// <param name="b">Második szám</param>
        /// <returns>Eredmény</returns>
        public static int Kivonas(int a, int b)
        {
            int c = a - b;
            return c;
        }
        /// <summary>
        /// Összeszoroz két számot
        /// </summary>
        /// <param name="a">Első szám</param>
        /// <param name="b">Második szám</param>
        /// <returns>Eredmény</returns>
        public static int Szorzas(int a, int b)
        {
            int c = a * b;
            return c;
        }
        /// <summary>
        /// Eloszt két számot, de ha valamelyik szám egyenlő 0-val, az eredmény is 0 lesz.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Osztas(int a, int b)
        {
            if (a == 0)
            {
                return 0;
            } else if (b == 0)
            {
                return 0;
            }
            int c = a / b;
            return c;
        }
        /// <summary>
        /// Megnézi hogy a szám a 2 többszöröse-e
        /// </summary>
        /// <param name="x">Szám</param>
        /// <returns>A 2 többszöröse-e, vagy sem</returns>
        public static bool KettoTobbszorose(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
        /// <summary>
        /// Az első szám gyökét keresi meg.
        /// </summary>
        /// <param name="a">Első szám</param>
        /// <returns>Eredmény</returns>
        public static double Gyokvonas(double a)
        {
            double b = System.Math.Sqrt(a);
            return b;
        }
    }
}
