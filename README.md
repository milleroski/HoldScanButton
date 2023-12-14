# Hold scan button
This mod allows you to hold the scan button to continuously keep scanning instead of having to spam the button.

## Installation guide

Install this like any other BepInEx mod, either manually of with r2modman / Thunderstore.

When installing manually, install the mod in the following directory:
```
\GAME_LOCATION\Lethal Company\BepInEx\plugins
```

This mod is completely client side, so no one else needs to install it besides the client for it to work.

## Compatibility

This mod is not fully compatible with ANY mod that applies a Harmony Prefix to the PingScan_performed method. As of writing this README there are two mods that do this:
- BetterItemScan
- Better Scanner

What this means for anyone using this mod is that you won't see the additional features these mods add if you keep holding the scan button for a while -- you will see it normally if you PRESS the button instead. This is very likely not fixable due to the technical explanation further below.

Below is an autohotkey script which spams the right click button (you can change it to your scan button) if you hold it. You can do this if this compatiblity issue REALLY bothers you and still want to retain this functionality.

```
#InstallMouseHook
Loop {
    BtnIsDown := GetKeyState("RButton", "P")
    While (BtnIsDown) {
        Send {RButton}
        BtnIsDown := GetKeyState("RButton", "P")
    }
}
```

### Technical explanation

This is due to the fact that it's (almost certainly) impossible to force the PingScan_performed method (method responsible for playing the scan animation etc.) to be called on every frame, due to the fact that it has a InputAction.CallbackContext parameter, which means that I need to provide it with some sort of InputAction Callback method, and as it stands right now, there are three of them in Unity: started(), performed(), and canceled(). None of these methods trigger a Callback on every frame, because they only trigger it on the exact FRAME that you've pressed the button. Since I can't just ignore this CallbackContext parameter, my theory is that it's literally impossible to program it in a way where I retain the original PingScan_performed function. If you're a modder and have ANY idea how to fix or work around this problem, please contact me, as I'm very interested in a potential solution to this problem.

## FAQ

### I found a bug / compatibility issue, where can I report this?

You can create an issue on my GitHub page linked at the very top, go to the #mod-releases forum on the community discord server (https://discord.gg/lethal-company), or just DM me on Discord (nickname: futuresavior).

## Credits
Thank you to rainycake for the idea and ashy!! for helping me figure out how to access the state of the input button. Thank you to Nebby for pointing out a compatibility issue that this mod causes.
