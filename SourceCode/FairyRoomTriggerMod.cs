using HarmonyLib;
using static FairyRoomState;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(FairyRoomTrigger), "InitializeTrigger")]
internal static class FairyRoomTrigger_InitializeTrigger {
    internal static void Postfix(FairyRoomController ___m_fairyRoomController) {
        FairyRoomState state = ___m_fairyRoomController.State;
        if (is_hud_visible_when_enemies_are_dead && (state == Failed || state == Passed)) {
            show_hud();
        }
    }
}
