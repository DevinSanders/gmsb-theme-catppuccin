using System.Collections.Generic;
using SoundBoard.PluginApi;

namespace CatppuccinThemePlugin;

/// <summary>
/// Catppuccin — a soothing pastel palette for hackers, ported to Game
/// Master Sound Board as a multi-palette theme pack.
///
/// <para>The official Catppuccin project (https://catppuccin.com) ships
/// four "flavors". This plugin exposes each as its own independent, flat
/// selectable palette:
/// <list type="bullet">
///   <item><b>Latte</b> — the light flavor; warm off-white surfaces with
///   muted pastel accents.</item>
///   <item><b>Frappé</b> — the warmest dark flavor; soft slate background
///   with peachy lavender accents.</item>
///   <item><b>Macchiato</b> — mid-darkness; deeper background, slightly
///   cooler than Frappé.</item>
///   <item><b>Mocha</b> — the darkest flavor; near-black background with
///   the most saturated pastel accents.</item>
/// </list></para>
///
/// <para>Each palette is a flat set of colours — one selectable look in the
/// host's theme dropdown. There is no Dark/Light variant: the host applies
/// the palette regardless of the active Avalonia variant and infers
/// light/dark Fluent chrome from the background luminance on its own.</para>
///
/// <para>Canonical color values are taken from the Catppuccin style guide
/// (https://github.com/catppuccin/catppuccin/blob/main/docs/style-guide.md).
/// Blue is used as the primary accent across all four flavors for
/// consistency with the official editor ports (VS Code, JetBrains, etc.).</para>
/// </summary>
public sealed class CatppuccinThemePlugin : IThemePlugin
{
    public string Id => "theme.catppuccin";
    public string Name => "Catppuccin";
    public string Version => PluginVersion.OfAssembly(typeof(CatppuccinThemePlugin));
    public string Author => "Devin Sanders";
    public string Description => "Catppuccin colour scheme: four flat palettes — Latte, Frappé, Macchiato, Mocha.";

    public void Initialize(IPluginContext context) { }
    public void Shutdown() { }

    public IEnumerable<ThemePalette> GetPalettes() => new[]
    {
        new ThemePalette("latte",      "Latte",
            new[] { "avares://CatppuccinThemePlugin/Themes/Latte.axaml" }),
        new ThemePalette("frappe",     "Frappé",
            new[] { "avares://CatppuccinThemePlugin/Themes/Frappe.axaml" }),
        new ThemePalette("macchiato",  "Macchiato",
            new[] { "avares://CatppuccinThemePlugin/Themes/Macchiato.axaml" }),
        new ThemePalette("mocha",      "Mocha",
            new[] { "avares://CatppuccinThemePlugin/Themes/Mocha.axaml" }),
    };
}
