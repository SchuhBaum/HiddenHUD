using BepInEx;
using UnityEngine;
using Wob_Common;

namespace HiddenHUD;

[BepInPlugin("SchuhBaum.HiddenHUD", "HiddenHUD", "0.0.1")]
public class MainMod : BaseUnityPlugin {
    // meta data
    public static string mod_id = "HiddenHUD";
    public static string author = "SchuhBaum";
    public static string version = "v0.0.1";

    // options
    public static bool is_fairy_rule_visible         = true;
    public static bool is_player_hud_visible         = false;
    public static bool is_player_minimap_visible     = false;
    public static bool is_relics_visible             = false;
    public static bool is_enemy_hud_visible          = false;
    public static bool is_now_entering_visible       = true;
    public static bool is_objective_complete_visible = true;
    public static bool is_global_timer_visible       = true;

	// variables
    public static bool is_initialized = false;

    protected void Awake() {
        if (is_initialized) return;
        is_initialized = true;
        WobPlugin.Initialise(this, this.Logger);

        WobSettings.Add(new WobSettings.Boolean("Options", "FairyRule", "", is_fairy_rule_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "PlayerHUD", "", is_player_hud_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "PlayerMinimap", "", is_player_minimap_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "Relics", "", is_relics_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "EnemyHUD", "", is_enemy_hud_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "NowEntering", "", is_now_entering_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "ObjectiveComplete", "", is_objective_complete_visible));
        WobSettings.Add(new WobSettings.Boolean("Options", "GlobalTimer", "", is_global_timer_visible));
        WobPlugin.Patch();

        is_fairy_rule_visible = WobSettings.Get("Options", "FairyRule", is_fairy_rule_visible);
        is_player_hud_visible = WobSettings.Get("Options", "PlayerHUD", is_player_hud_visible);
        is_player_minimap_visible = WobSettings.Get("Options", "PlayerMinimap", is_player_minimap_visible);
        is_relics_visible = WobSettings.Get("Options", "Relics", is_relics_visible);
        is_enemy_hud_visible = WobSettings.Get("Options", "EnemyHUD", is_enemy_hud_visible);
        is_now_entering_visible = WobSettings.Get("Options", "NowEntering", is_now_entering_visible);
        is_objective_complete_visible = WobSettings.Get("Options", "ObjectiveComplete", is_objective_complete_visible);
        is_global_timer_visible = WobSettings.Get("Options", "GlobalTimer", is_global_timer_visible);

        Debug.Log(mod_id + ": author "                        + author);
        Debug.Log(mod_id + ": version "                       + version);
        Debug.Log(mod_id + ": is_fairy_rule_visible "         + is_fairy_rule_visible);
        Debug.Log(mod_id + ": is_player_hud_visible "         + is_player_hud_visible);
        Debug.Log(mod_id + ": is_player_minimap_visible "     + is_player_minimap_visible);
        Debug.Log(mod_id + ": is_relics_visible "             + is_relics_visible);
        Debug.Log(mod_id + ": is_enemy_hud_visible "          + is_enemy_hud_visible);
        Debug.Log(mod_id + ": is_now_entering_visible "       + is_now_entering_visible);
        Debug.Log(mod_id + ": is_objective_complete_visible " + is_objective_complete_visible);
        Debug.Log(mod_id + ": is_global_timer_visible "       + is_global_timer_visible);
    }
}
