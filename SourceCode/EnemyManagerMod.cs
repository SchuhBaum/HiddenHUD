using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(EnemyManager), "LateUpdate")]
internal static class EnemyManager_LateUpdate {
    // This function is called immediately after LateUpdate() updates the variable
    // SummonedEnemyList.
    internal static void Postfix() {
        while (active_enemy_spawn_controller_list.Count > 0 && active_enemy_spawn_controller_list[active_enemy_spawn_controller_list.Count-1].IsDead) {
            active_enemy_spawn_controller_list.RemoveAt(active_enemy_spawn_controller_list.Count-1);
        }

        if (!is_hud_visible && is_hud_visible_when_enemies_are_dead && EnemyManager.SummonedEnemyList.Count == 0 && active_enemy_spawn_controller_list.Count == 0) {
            show_hud();
            return;
        }

        // There are multiple methods where enemies can be summoned with. It is
        // easier to just check it here.
        if (is_hud_visible && EnemyManager.SummonedEnemyList.Count > 0) {
            hide_hud();
            return;
        }
    }
}
