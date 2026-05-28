# gmsb-theme-catppuccin

Catppuccin theme pack for [Game Master Sound Board](https://github.com/DevinSanders/game-master-soundboard).

Four independent, flat palettes drawn from the [Catppuccin](https://catppuccin.com) project — the popular soothing pastel scheme adopted by VS Code, JetBrains, Discord, Obsidian, and dozens of other developer tools. One light flavor and three dark flavors of increasing darkness, each its own dropdown entry:

| Palette    | Look      | Notes |
|------------|-----------|-------|
| Latte      | Light     | Warm off-white surfaces with muted pastel accents. |
| Frappé     | Dark      | Warmest dark flavor; soft slate background with peachy lavender accents. |
| Macchiato  | Dark      | Mid-darkness; deeper background, cooler tones than Frappé. |
| Mocha      | Dark      | Darkest flavor; near-black background with the most saturated accents. |

Each palette is a flat set of colours — one selectable look in the host's theme dropdown (shown as "Catppuccin: Latte", "Catppuccin: Mocha", etc.). There is no Dark/Light variant: the host applies the palette regardless of the active Avalonia variant and infers light/dark Fluent chrome (scrollbars, popups, focus rings) from the background luminance on its own.

## Install

Drop the released `.zip` onto Settings → Plugin Manager. Themes activate live — no restart needed. Pick the palette from Settings → Appearance → Theme.

Pre-built zips are attached to each [GitHub Release](../../releases).

## Build

```powershell
dotnet build src/CatppuccinThemePlugin.csproj
pwsh scripts/package.ps1
# → dist/github.DevinSanders-theme.catppuccin-1.0.0.zip
```

Requires .NET 10 SDK. `SoundBoard.PluginApi` is restored from NuGet automatically — no sibling checkout needed.

## Plugin manifest

| Field     | Value                            |
|-----------|----------------------------------|
| publisher | `github.DevinSanders`            |
| id        | `theme.catppuccin`               |
| entryDll  | `CatppuccinThemePlugin.dll`      |
| isTheme   | `true`                           |

## Attribution

Color values from the official [Catppuccin style guide](https://github.com/catppuccin/catppuccin/blob/main/docs/style-guide.md), released under the MIT license. This pack adapts the palette to Game Master Sound Board's semantic key vocabulary; it is not an official Catppuccin port.

## License

Released under the [MIT License](LICENSE).

Catppuccin colors are © Catppuccin Org and licensed under MIT — see https://github.com/catppuccin/catppuccin/blob/main/LICENSE.
