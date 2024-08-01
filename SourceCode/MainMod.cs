using System.Collections.Generic;
using BepInEx;
using UnityEngine;
using Wob_Common;
using static EnemyType;

namespace HiddenHUD;

[BepInPlugin("SchuhBaum.HiddenHUD", "HiddenHUD", "0.0.4")]
public class MainMod : BaseUnityPlugin {
    // meta data
    public static string author = "SchuhBaum";
    public static string mod_id = "HiddenHUD";
    public static string version = "v0.0.4";

    // options
    public static bool is_enemy_hud_visible                 = false;
    public static bool is_fairy_rule_visible                = true;
    public static bool is_global_timer_visible              = true;
    public static bool is_hud_visible_when_enemies_are_dead = true;
    public static bool is_now_entering_visible              = true;
    public static bool is_objective_complete_visible        = true;
    public static bool is_player_hud_visible                = false;
    public static bool is_player_minimap_visible            = false;
    public static bool is_relics_visible                    = false;

	// variables
    public static List<EnemySpawnController> active_enemy_list = new();
    public static bool is_initialized = false;

    //
    // main
    //

    protected void Awake() {
        if (is_initialized) return;
        is_initialized = true;
        WobPlugin.Initialise(this, this.Logger);

        WobSettings.Add(new WobSettings.Boolean("Options", "is_enemy_hud_visible", "", is_enemy_hud_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_fairy_rule_visible", "", is_fairy_rule_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_global_timer_visible", "", is_global_timer_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_hud_visible_when_enemies_are_dead", "", is_hud_visible_when_enemies_are_dead));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_now_entering_visible", "", is_now_entering_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_objective_complete_visible", "", is_objective_complete_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_player_hud_visible", "", is_player_hud_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_player_minimap_visible", "", is_player_minimap_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "is_relics_visible", "", is_relics_visible));
        WobPlugin.Patch();

        is_enemy_hud_visible                 = WobSettings.Get("Options", "is_enemy_hud_visible", is_enemy_hud_visible);
        is_fairy_rule_visible                = WobSettings.Get("Options", "is_fairy_rule_visible", is_fairy_rule_visible);
        is_global_timer_visible              = WobSettings.Get("Options", "is_global_timer_visible", is_global_timer_visible);
        is_hud_visible_when_enemies_are_dead = WobSettings.Get("Options", "is_hud_visible_when_enemies_are_dead", is_hud_visible_when_enemies_are_dead);
        is_now_entering_visible              = WobSettings.Get("Options", "is_now_entering_visible", is_now_entering_visible);
        is_objective_complete_visible        = WobSettings.Get("Options", "is_objective_complete_visible", is_objective_complete_visible);
        is_player_hud_visible                = WobSettings.Get("Options", "is_player_hud_visible", is_player_hud_visible);
        is_player_minimap_visible            = WobSettings.Get("Options", "is_player_minimap_visible", is_player_minimap_visible);
        is_relics_visible                    = WobSettings.Get("Options", "is_relics_visible", is_relics_visible);

        Debug.Log(mod_id + ": author "                        + author);
        Debug.Log(mod_id + ": version "                       + version);

        Debug.Log(mod_id + ": is_enemy_hud_visible "          + is_enemy_hud_visible);
        Debug.Log(mod_id + ": is_fairy_rule_visible "         + is_fairy_rule_visible);
        Debug.Log(mod_id + ": is_global_timer_visible "       + is_global_timer_visible);
        Debug.Log(mod_id + ": is_hud_visible_when_enemies_are_dead "         + is_hud_visible_when_enemies_are_dead);
        Debug.Log(mod_id + ": is_now_entering_visible "       + is_now_entering_visible);
        Debug.Log(mod_id + ": is_objective_complete_visible " + is_objective_complete_visible);
        Debug.Log(mod_id + ": is_player_hud_visible "         + is_player_hud_visible);
        Debug.Log(mod_id + ": is_player_minimap_visible "     + is_player_minimap_visible);
        Debug.Log(mod_id + ": is_relics_visible "             + is_relics_visible);
    }

    //
    // public
    //

    public static void hide_hud() {
        if (!is_fairy_rule_visible)         HUDManager.SetHUDVisible(HUDType.FairyRule, false);
        if (!is_player_hud_visible)         HUDManager.SetHUDVisible(HUDType.PlayerHUD, false);
        if (!is_player_minimap_visible)     HUDManager.SetHUDVisible(HUDType.PlayerMinimap, false);
        if (!is_relics_visible)             HUDManager.SetHUDVisible(HUDType.Relics, false);
        if (!is_enemy_hud_visible)          HUDManager.SetHUDVisible(HUDType.EnemyHUD, false);
        if (!is_now_entering_visible)       HUDManager.SetHUDVisible(HUDType.NowEntering, false);
        if (!is_objective_complete_visible) HUDManager.SetHUDVisible(HUDType.ObjectiveComplete, false);
        if (!is_global_timer_visible)       HUDManager.SetHUDVisible(HUDType.GlobalTimer, false);
    }

    public static void show_hud() {
        if (!is_fairy_rule_visible)         HUDManager.SetHUDVisible(HUDType.FairyRule, true);
        if (!is_player_hud_visible)         HUDManager.SetHUDVisible(HUDType.PlayerHUD, true);
        if (!is_player_minimap_visible)     HUDManager.SetHUDVisible(HUDType.PlayerMinimap, true);
        if (!is_relics_visible)             HUDManager.SetHUDVisible(HUDType.Relics, true);
        if (!is_enemy_hud_visible)          HUDManager.SetHUDVisible(HUDType.EnemyHUD, true);
        if (!is_now_entering_visible)       HUDManager.SetHUDVisible(HUDType.NowEntering, true);
        if (!is_objective_complete_visible) HUDManager.SetHUDVisible(HUDType.ObjectiveComplete, true);
        if (!is_global_timer_visible)       HUDManager.SetHUDVisible(HUDType.GlobalTimer, true);
    }

    public static void update_active_enemy_list(BaseRoom room) {
        active_enemy_list.Clear();
        foreach (EnemySpawnController enemy_spawn_controller in room.SpawnControllerManager.EnemySpawnControllers) {
            if (enemy_spawn_controller.IsDead) continue;
            if (enemy_spawn_controller.Type == BouncySpike) continue;
            if (enemy_spawn_controller.Type == Dummy) continue;
            if (enemy_spawn_controller.Type == Target) continue;
            active_enemy_list.Add(enemy_spawn_controller);
        }
    }
}
