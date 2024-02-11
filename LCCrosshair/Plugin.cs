using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace LCCrosshair
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CrosshairBase : BaseUnityPlugin
    {
        private const string modGUID = "Polin.Crosshair";
        private const string modName = "Crosshair";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CrosshairBase Instance;

        internal ManualLogSource mls;

        public static ConfigEntry<bool> configEnabled;

        public static ConfigEntry<string> configImage;

        public static ConfigEntry<float> configHeight;

        public static ConfigEntry<float> configWidth;

        public static ConfigEntry<int> configR;

        public static ConfigEntry<int> configG;

        public static ConfigEntry<int> configB;

        public static ConfigEntry<int> configA;

        public static Color32 crosshairColor;

        public static Sprite crosshairIcon;

        private static string getPath;

        public static string GetPath
        {
            get
            {
                if(getPath == null)
                {
                    getPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
                }
                return getPath;
            }
        }

        public static void Log(string msg)
        {
            Instance.Logger.LogInfo("[LC Crosshair Mod]" + msg);
        }


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            configR = base.Config.Bind("Color", "r", 255, "Red value of crosshair (0-255)");

            configG = base.Config.Bind("Color", "g", 255, "Green value of crosshair (0-255)");

            configB = base.Config.Bind("Color", "b", 255, "Blue value of crosshair (0-255)");

            configA = base.Config.Bind("Color", "a", 255, "Alpha value of crosshair (0-255)");

            configHeight = base.Config.Bind("Size", "height", 10f, "Height of crosshair");

            configWidth = base.Config.Bind("Size", "width", 10f, "Width of crosshair");

            configEnabled = base.Config.Bind("General", "enabled", defaultValue: true, "Crosshair visibility");

            configImage = base.Config.Bind("General", "image", "crosshair.png", "Crosshair image");

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo(modGUID + " has launched successfully >:)");

            if(configEnabled.Value)
            {
                if(configImage.Value != string.Empty)
                {
                    LoadIcon(Path.Combine(GetPath, configImage.Value));
                }
                crosshairColor = new Color32((byte)configR.Value, (byte)configG.Value, (byte)configB.Value, (byte)configA.Value);
                harmony.PatchAll();
            }

            harmony.PatchAll(typeof(CrosshairBase));
        }

        internal static void LoadIcon(string filePath)
        {
            if(!File.Exists(filePath))
            {
                Log("[Image not found: " + filePath + ", default crosshair used");
                return;
            }
            try
            {
                byte[] array = File.ReadAllBytes(filePath);
                Texture2D val = new Texture2D(2, 2, (TextureFormat)5, false);
                ImageConversion.LoadImage(val, array);
                ((Texture)val).filterMode = (FilterMode)0;
                crosshairIcon = Sprite.Create(val, new Rect(0f, 0f, (float)((Texture)val).width, (float)((Texture)val).height), new Vector2(0.5f, 0.5f), Mathf.Min(configWidth.Value, configHeight.Value));
                Log("Image " + filePath + " loaded");
            }
            catch (Exception)
            {
                Log("Crosshair image is not readable, " + filePath + " default crosshair used");
            }
        }
    }
}
