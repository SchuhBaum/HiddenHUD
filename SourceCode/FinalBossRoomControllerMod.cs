using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(FinalBossRoomController), "SmashWindows")]
internal static class FinalBossRoomController_SmashWindows {
    internal static void Postfix() {
        // Apparently, the spawn controller for both - the normal and true form
        // boss - are active. Clear them here as a workaround. The weird thing
        // is that other bosses don't seem to need that.
        active_enemy_spawn_controller_list.Clear();
    }
}
