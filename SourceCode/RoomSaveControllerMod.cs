using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(RoomSaveController), "OnPlayerEnter_LoadStageData")]
internal static class PlayerController_EnterRoom {
    internal static void Postfix() {
        number_of_active_enemies = get_number_of_active_enemies_in_room(PlayerManager.GetCurrentPlayerRoom());
        if (is_hud_visible_when_enemies_are_dead && number_of_active_enemies <= 0) {
            show_hud();
            return;
        }
        hide_hud();
    }
}
