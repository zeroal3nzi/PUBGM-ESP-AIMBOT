using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGMESP
{
    internal class Settings
    {
        public static bool PlayerESP = true;
        public static bool PlayerBone = true;
        public static bool PlayerBox = true;
        public static bool Player3dBox = false;
        public static bool PlayerLines = true;
        public static bool PlayerHealth = true;
        public static bool ItemESP = false;
        public static bool VehicleESP = false;
        public static bool SpeedCar = false;
        public static bool FastLanding = false;
        // aimbot
        public static bool aimEnabled = true;
        public static bool bDrawFow = true;
        public static int bSmooth = 7;
        public static int bFovInt = 1;
        public static int bPredict = 1;
        public static int bYAxis = 2;
        public static int bAimKeyINT = 2;
        public static System.Windows.Forms.Keys[] bAimKeys = new System.Windows.Forms.Keys[] { System.Windows.Forms.Keys.CapsLock, System.Windows.Forms.Keys.LButton, System.Windows.Forms.Keys.RButton, System.Windows.Forms.Keys.LShiftKey, System.Windows.Forms.Keys.V, System.Windows.Forms.Keys.E, System.Windows.Forms.Keys.Q };
        public static float[] bFovArray = new float[]
        {
            60f,
            90f,
            120f,
            160f,
            300f
        };
    }
}
