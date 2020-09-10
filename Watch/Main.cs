using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Harmony;
using System.Reflection;
using TMPro;

namespace Watch
{
    public class Main : VTOLMOD
    {
        public static bool leftHand = true;
        public static TextMeshPro watchText;

        public UnityAction<bool> leftHand_changed;

        public override void ModLoaded()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("cheese.skijump");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            base.ModLoaded();
            //VTOLAPI.SceneLoaded += SceneLoaded;
            //VTOLAPI.MissionReloaded += MissionReloaded;

            Settings settings = new Settings(this);
            settings.CreateCustomLabel("Watch Settings");

            leftHand_changed += leftHand_Setting;
            settings.CreateBoolSetting("Watch on left hand?", leftHand_changed, leftHand);

            VTOLAPI.CreateSettingsMenu(settings);
        }

        public void leftHand_Setting(bool newval)
        {
            leftHand = newval;
        }

        void Update() {
            if (watchText != null)
            {
                watchText.text = DateTime.Now.ToString("HH:mm:ss");
            }
        }
    }
}