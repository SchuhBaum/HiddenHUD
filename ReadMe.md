## HiddenHUD
###### Version: 0.0.8
This is a mod for Rogue Legacy 2.

### Description
Hides the player HUD and other elements like the minimap. Can be configured in the file `[...]/Rogue Legacy 2/BepInEx/config/SchuhBaum.HiddenHUD.cfg`.

Here is a youtube video:  
[https://www.youtube.com/watch?v=AwMJlXWB9Ic](https://www.youtube.com/watch?v=AwMJlXWB9Ic)

### Installation of the ModLoader BepInEx
1. Download the file `BepInEx_win_x64_5.4.23.2.zip` (or newer) from [here](https://github.com/BepInEx/BepInEx/releases).
2. Extract its content in the folder `[Steam]/SteamApps/common/Rogue Legacy 2` (this is the folder that contains the file `Rogue Legacy 2.exe`)

### Installation of this Mod
1. Download the file `HiddenHUD.zip` from [Releases](https://github.com/SchuhBaum/HiddenHUD/releases/tag/v0.0.8).
2. Again, extract its content in the folder `[Steam]/SteamApps/common/Rogue Legacy 2`.
3. Start the game as normal.

You can check the logs for errors or if you have installed BepInEx and the mod correctly. There are two logs -- `[...]/Rogue Legacy 2/BepInEx/LogOutput.log` and `[User]/AppData/LocalLow/Cellar Door Games/Rogue Legacy 2/Player.log`.
In the logs, you should see entries like `[Info:BepInEx] Loading [HiddenHUD 0.0.8]`.

### Bug reports
Please describe step-by-step how to reproduce the issue. You can post them here on GitHub under the tab `Issues`.

### Source Code
This mod uses the mod template from `wobat`:  
[https://www.nexusmods.com/roguelegacy2/mods/24](https://www.nexusmods.com/roguelegacy2/mods/24)

### Contact
If you have feedback, you can message me on Discord `@schuhbaum` or write an email to SchuhBaum71@gmail.com.

### License
See the file LICENSE-MIT.

### Changelog
v0.0.8:
- Restored parts of v0.0.6. Restoring the hud earlier after boss fights was too buggy.

v0.0.7:
- Restore the hud a bit earlier for all boss fights.
- Fixed a bug where Eggplants would count as enemies.

v0.0.6:
- Fixed a bug where the hud would not be visible again after the final boss died.
- Fixed an exception.

v0.0.5:
- Handle summoned enemies as well. Hide hud again if enemies are summoned.

v0.0.4:
- Fixed a bug where the hud would not be visible in fairy rooms with enemy spawner.

v0.0.3:
- Fixed a bug where dummies and targets would count as enemies.
- Fixed a bug where the hud would not be visible after (mini-)boss fights.

v0.0.2:
- Added the option is_hud_visible_when_enemies_are_dead (enabled by default).

v0.0.1:
- Initial release.
