using HarmonyLib;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(CaveBoss_Basic_AIScript), "DeathAnim")]
internal static class CaveBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(DancingBoss_Basic_AIScript), "DeathAnim")]
internal static class DancingBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(EyeballBoss_Basic_AIScript), "DeathAnim")]
internal static class EyeballBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(FinalBoss_Basic_AIScript), "DeathAnim")]
internal static class FinalBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        // Apparently, the spawn controller for both - the normal and the true
        // form - are active for the final boss. Clear them here as a workaround.
        // For consistency do this for all bosses. Then the hud appears a bit earlier
        // as well. It appears when the animation starts and not when it ends.
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(MimicChestBoss_Basic_AIScript), "DeathAnim")]
internal static class MimicChestBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(SkeletonBoss_Basic_AIScript), "DeathAnim")]
internal static class SkeletonBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(SpellswordBoss_Basic_AIScript), "DeathAnim")]
internal static class SpellswordBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(StudyBoss_Basic_AIScript), "DeathAnim")]
internal static class StudyBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}

[HarmonyPatch(typeof(TraitorBoss_Basic_AIScript), "DeathAnim")]
internal static class TraitorBoss_Basic_AIScript_DeathAnim {
    internal static void Postfix() {
        active_enemy_spawn_controller_list.Clear();
    }
}
