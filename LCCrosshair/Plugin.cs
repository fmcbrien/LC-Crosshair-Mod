using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCCrosshair
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CrosshairBase : BaseUnityPlugin
    {
        private const string modGUID = "Teehee.Crosshair";
        private const string modName = "Crosshair";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CrosshairBase Instance;

        internal ManualLogSource mls;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The test mod has started >:)");

            harmony.PatchAll(typeof(CrosshairBase));
        }
    }
}
