using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using LCCrosshair;

namespace LCCrosshair.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        private static float xPos;

        private static float yPos;

        public static List<Image> crosshairImage;

        public static HUDElement crosshair;

        [HarmonyPatch(typeof(HUDManager), "Start")]
        [HarmonyPostfix]
        public static void Start(ref HUDManager __instance)
        {
            GameObject crosshair = new GameObject("Crosshair");
            RectTransform crosshairTransform = crosshair.AddComponent<RectTransform>();
            Image crosshairImage = crosshair.AddComponent<Image>();
            crosshair.transform.SetParent(__instance.HUDContainer.transform, false);
            crosshair.transform.SetAsLastSibling();
            crosshairImage.sprite = CrosshairBase.crosshairIcon;
            crosshairImage.color = CrosshairBase.crosshairColor;
            crosshairTransform.sizeDelta = new Vector2(CrosshairBase.configWidth.Value, CrosshairBase.configHeight.Value);
        }
    }
}
