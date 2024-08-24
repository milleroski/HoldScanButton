using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HoldScanButton.Patches;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class HoldScanButtonPlugin : BaseUnityPlugin
{
    private readonly Harmony harmony = new Harmony(LCMPluginInfo.PLUGIN_GUID);

    public static HoldScanButtonPlugin Instance;

    internal ManualLogSource logger;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        logger = BepInEx.Logging.Logger.CreateLogSource(LCMPluginInfo.PLUGIN_GUID);
        logger.LogInfo("Plugin HoldScanButton has loaded!");

        harmony.PatchAll(typeof(HoldScanButtonPatch));
    }
}
