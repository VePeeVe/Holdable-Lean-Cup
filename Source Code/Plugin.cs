using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace lean
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        static bool isEnabled = true;
        static GameObject leanObject;

        void Awake()
        {
            Events.GameInitialized += OnGameInitialized;
        }

        void Start()
        {
            Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            isEnabled = true;
            if (leanObject != null)
            {
                leanObject.SetActive(isEnabled);
            }
        }

        void OnDisable()
        {
            isEnabled = false;
            if (leanObject != null)
            {
                leanObject.SetActive(isEnabled);
            }
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("lean.Assets.lean");
            AssetBundle assetBundle = AssetBundle.LoadFromStream(manifestResourceStream);
            GameObject tempGameObject = assetBundle.LoadAsset<GameObject>("lean");
            leanObject = Instantiate(tempGameObject);

            GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L");
            leanObject.transform.position = new Vector3(-0.050f, 0.06f, 0.05f);
            leanObject.transform.localScale = new Vector3(0.8098716f, 0.8098716f, 0.8098716f);
            leanObject.transform.rotation = Quaternion.Euler(100f, 180f, 90.0f);
            leanObject.transform.SetParent(hand.transform, false);

            leanObject.SetActive(isEnabled);
        }
    }
}
