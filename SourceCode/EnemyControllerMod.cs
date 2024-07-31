using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(EnemyController), "KillCharacter")]
internal static class EnemyController_KillCharacter {
    internal static void Postfix(EnemyController __instance) {
        if (number_of_active_enemies <= 0) return;
        if (__instance.Room != PlayerManager.GetCurrentPlayerRoom()) return;
        if (!__instance.IsDead && !__instance.StatusEffectController.HasStatusEffect(StatusEffectType.Enemy_DeathDelay)) return;

        number_of_active_enemies -= 1;
        if (number_of_active_enemies <= 0) {
            // Do this in case some enemies did spawn after the room loaded. Might
            // not be required. Just to be safe.
            number_of_active_enemies = get_number_of_active_enemies_in_room(PlayerManager.GetCurrentPlayerRoom());
        }
        if (is_hud_visible_when_enemies_are_dead && number_of_active_enemies <= 0) {
            show_hud();
        }
    }
}
