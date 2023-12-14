using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HoldScanButton.Patches;

namespace HoldScanButton
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class HoldScanButtonPlugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        public static HoldScanButtonPlugin Instance;

        internal ManualLogSource logger;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            logger = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.PLUGIN_GUID);
            logger.LogInfo("Plugin HoldScanButton has loaded!");

            harmony.PatchAll(typeof(HoldScanButtonPatch));
        }
    }
}