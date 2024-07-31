using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(RoomSaveController), "OnPlayerEnter_LoadStageData")]
internal static class PlayerController_EnterRoom {
    internal static void Postfix() {
        update_active_enemy_list(PlayerManager.GetCurrentPlayerRoom());
        if (is_hud_visible_when_enemies_are_dead && active_enemy_list.Count == 0) {
            show_hud();
            return;
        }
        hide_hud();
    }
}
