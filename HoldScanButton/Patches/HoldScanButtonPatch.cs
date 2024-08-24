using HarmonyLib;
using UnityEngine.InputSystem;

namespace HoldScanButton.Patches
{

    internal class HoldScanButtonPatch
    {
        static InputAction.CallbackContext pingContext;

        [HarmonyPatch(typeof(HUDManager), "Update")]
        [HarmonyPostfix]
        static void UpdatePatch(HUDManager __instance)
        {
            // If the PingScan button is pressed, call the PingScan_performed function with our captured context
            if (IngamePlayerSettings.Instance.playerInput.actions.FindAction("PingScan").IsPressed())
            {
                __instance.PingScan_performed(pingContext);
            }
        }

        // Patch the HudManager.PingScan_performed function so we can capture the context for future reuse
        [HarmonyPatch(typeof(HUDManager), "PingScan_performed")]
        [HarmonyPrefix]
        static void OnScan(HUDManager __instance, InputAction.CallbackContext context)
        {
            pingContext = context;
        }

        //// Disable the PingScan_performed method completely.
        //[HarmonyPatch(typeof(HUDManager), "PingScan_performed")]
        //[HarmonyPrefix]
        //static bool PingScanPatch(HUDManager __instance)
        //{
        //    return false;
        //}
    }
}