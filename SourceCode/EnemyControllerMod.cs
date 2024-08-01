using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(EnemyController), "KillCharacter")]
internal static class EnemyController_KillCharacter {
    internal static void Postfix(EnemyController __instance) {
        if (!active_enemy_list.Contains(__instance.EnemySpawnController)) return;
        active_enemy_list.Remove(__instance.EnemySpawnController);

        if (is_hud_visible_when_enemies_are_dead && active_enemy_list.Count == 0) {
            show_hud();
        }
    }
}
