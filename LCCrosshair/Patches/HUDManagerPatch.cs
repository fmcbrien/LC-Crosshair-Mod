using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCCrosshair.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    public static class HUDManagerPatch
    {
        private static float xPos;

        private static float yPos;

        public static List<Image> crosshairImage; //TODO figure out how to put image in unity

        public static HUDElement crosshair;

        [HarmonyPatch(typeof(HUDManager), "Awake")]
        [HarmonyPostfix]
        public static void initialize()
        {
            
        }
    }
}
