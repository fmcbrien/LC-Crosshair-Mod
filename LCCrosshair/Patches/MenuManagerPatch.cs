using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using LCCrosshair;

namespace LCCrosshair.Patches
{
    [HarmonyPatch(typeof(MenuManager))]
    internal class MenuManagerPatch
    {
        private static Image menuButtonCrosshair;

        private static AudioSource audio;

        private static AudioClip sfx;

        public static HUDElement crosshair;

        [HarmonyPatch(typeof(MenuManager), "Awake")]
        [HarmonyPostfix]
        public static void Awake(ref MenuManager __instance)
        {
            if (!(__instance?.versionNumberText == null))
            {
                Canvas componentInParent = __instance.versionNumberText.GetComponentInParent<Canvas>();
                GameObject gameObject = new GameObject("CrosshairSettings");
                RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
                menuButtonCrosshair = gameObject.AddComponent<Image>();
                Button button = gameObject.AddComponent<Button>();
                button.targetGraphic = menuButtonCrosshair;
                button.onClick.AddListener(OnClick);
                gameObject.transform.SetParent(componentInParent.transform, worldPositionStays: false);
                gameObject.transform.SetAsLastSibling();
                menuButtonCrosshair.sprite = CrosshairBase.crosshairIcon;
                menuButtonCrosshair.color = CrosshairBase.crosshairColor;
                rectTransform.sizeDelta /= 3f;
                RectTransform rectTransform2 = rectTransform;
                RectTransform rectTransform3 = rectTransform;
                Vector2 vector = (rectTransform.pivot = Vector2.one);
                Vector2 anchorMin = (rectTransform3.anchorMax = vector);
                rectTransform2.anchorMin = anchorMin;
                rectTransform.anchoredPosition = new Vector2(-50f, -20f);
                audio = __instance.MenuAudio;
                sfx = __instance.openMenuSound;
                GameObject gameObject2 = new GameObject("CrosshairLabel");
                rectTransform = gameObject2.AddComponent<RectTransform>();
                TextMeshProUGUI textMeshProUGUI = gameObject2.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.alignment = TextAlignmentOptions.Top;
                textMeshProUGUI.SetText("Set Crosshair");
                textMeshProUGUI.fontSize /= 3f;
                gameObject2.transform.SetParent(button.transform, worldPositionStays: false);
                RectTransform rectTransform4 = rectTransform;
                anchorMin = (rectTransform.anchorMax = new Vector2(0.5f, 0f));
                rectTransform4.anchorMin = anchorMin;
                rectTransform.pivot = new Vector2(0.5f, 1f);
                rectTransform.anchoredPosition = new Vector2(0f, -5f);
            }
        }

        private static void OnClick()
        {
            audio.PlayOneShot(sfx, 1f);
            List<string> list = Directory.EnumerateFiles(CrosshairBase.GetPath, "*.png").ToList();
            int num = list.FindIndex((string f) => f.Contains(CrosshairBase.configImage.Value));
            int whichCrosshair = 0;
            whichCrosshair = ((num > -1 && num < list.Count - 1) ? (num + 1) : 0);
            CrosshairBase.configImage.SetSerializedValue(list[whichCrosshair].Replace(CrosshairBase.GetPath, string.Empty).TrimStart('\\'));
            CrosshairBase.Log("Changed crosshair to: " + list[whichCrosshair]);
            CrosshairBase.LoadIcon(list[whichCrosshair]);
            menuButtonCrosshair.sprite = CrosshairBase.crosshairIcon;
        }
    }
}
