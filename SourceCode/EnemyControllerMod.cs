using HarmonyLib;
// using UnityEngine;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(EnemyController), "KillCharacter")]
internal static class EnemyController_KillCharacter {
    internal static void Postfix(EnemyController __instance) {
        // Debug.Log("TEMP: EnemyController_KillCharacter");
        // Debug.Log("TEMP: name " + __instance.name);
        if (!active_enemy_list.Contains(__instance.EnemySpawnController)) return;
        active_enemy_list.Remove(__instance.EnemySpawnController);
        // Debug.Log("TEMP: 2");

        if (is_hud_visible_when_enemies_are_dead && active_enemy_list.Count == 0) {
            show_hud();
        }
    }
}
