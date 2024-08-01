using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(EnemyController), "KillCharacter")]
internal static class EnemyController_KillCharacter {
    internal static void Postfix(EnemyController __instance) {
        if (active_enemy_spawner_list.Contains(__instance.EnemySpawnController)) {
            active_enemy_spawner_list.Remove(__instance.EnemySpawnController);
        }
    }
}
