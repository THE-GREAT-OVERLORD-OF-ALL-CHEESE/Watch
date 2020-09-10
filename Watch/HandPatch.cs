using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine;
using TMPro;

[HarmonyPatch(typeof(VRHandController), "Awake")]
class Patch0
{
    [HarmonyPostfix]
    public static void Postfix(VRHandController __instance)
    {
        Debug.Log("Hand Awake!");

        if (Watch.Main.leftHand == __instance.isLeft) {
            GameObject watchObject = new GameObject();
            watchObject.transform.parent = __instance.transform;
            if (__instance.isLeft)
            {
                watchObject.transform.localPosition = new Vector3(-0.0577f, 0.01f, -0.1243f);
                watchObject.transform.localEulerAngles = new Vector3(180, -90, 60);
            }
            else {
                watchObject.transform.localPosition = new Vector3(0.0577f, 0.01f, -0.118f);
                watchObject.transform.localEulerAngles = new Vector3(180, 90, -60);
            }

            TextMeshPro tmp = watchObject.AddComponent<TextMeshPro>();
            tmp.text = "Placeholder";
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.fontSize = 0.15f;

            Watch.Main.watchText = tmp;
        }
    }
}
