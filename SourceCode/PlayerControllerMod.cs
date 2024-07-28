using System;
using HarmonyLib;
using UnityEngine;
using static HiddenHUD.MainMod;

namespace HiddenHUD;

[HarmonyPatch(typeof(PlayerController), "EnterRoom", new Type[] { typeof(BaseRoom), typeof(Door), typeof(Vector3) })]
internal static class PlayerController_EnterRoom {
    internal static void Postfix(BaseRoom room, Door door, Vector3 localPosition) {
        if (!is_fairy_rule_visible) HUDManager.SetHUDVisible(HUDType.FairyRule, false);
        if (!is_player_hud_visible) HUDManager.SetHUDVisible(HUDType.PlayerHUD, false);
        if (!is_player_minimap_visible) HUDManager.SetHUDVisible(HUDType.PlayerMinimap, false);
        if (!is_relics_visible) HUDManager.SetHUDVisible(HUDType.Relics, false);
        if (!is_enemy_hud_visible) HUDManager.SetHUDVisible(HUDType.EnemyHUD, false);
        if (!is_now_entering_visible) HUDManager.SetHUDVisible(HUDType.NowEntering, false);
        if (!is_objective_complete_visible) HUDManager.SetHUDVisible(HUDType.ObjectiveComplete, false);
        if (!is_global_timer_visible) HUDManager.SetHUDVisible(HUDType.GlobalTimer, false);
    }
}
