using HarmonyLib;

namespace HoldScanButton.Patches
{

    internal class HoldScanButtonPatch
    {

        [HarmonyPatch(typeof(HUDManager), "Update")]
        [HarmonyPrefix]
        static void UpdatePatch(HUDManager __instance)
        {
            // This is simple. Instead of using PingScan_performed method, just trigger the same function but without the callback IF the PingScan button is pressed.
            if (IngamePlayerSettings.Instance.playerInput.actions.FindAction("PingScan").IsPressed())
            {
                ScanButtonHeld(__instance);
            }
        }
        
        // Just run the same code as the PingScan_performed method but without the CallbackContext parameter.
        private static void ScanButtonHeld(HUDManager __instance)
        {
            if (GameNetworkManager.Instance.localPlayerController == null)
            {
                return;
            }
            if (!__instance.CanPlayerScan())
            {
                return;
            }
            if (__instance.playerPingingScan <= -1f)
            {
                __instance.playerPingingScan = 0.3f;
                __instance.scanEffectAnimator.transform.position = GameNetworkManager.Instance.localPlayerController.gameplayCamera.transform.position;
                __instance.scanEffectAnimator.SetTrigger("scan");
                __instance.UIAudio.PlayOneShot(__instance.scanSFX);
            }
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