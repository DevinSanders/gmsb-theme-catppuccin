using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using FluentAssertions;
using SoundBoard.PluginApi;
using Xunit;

namespace CatppuccinThemePlugin.Tests;

public class PaletteTests
{
    // The four palettes this pack ships, as (id, name, avares-uri). Kept in
    // lockstep with CatppuccinThemePlugin.GetPalettes(); the catalog test
    // below is what enforces that they stay in sync.
    public static readonly (string Id, string Name, string Uri)[] Expected =
    {
        ("latte",     "Latte",     "avares://CatppuccinThemePlugin/Themes/Latte.axaml"),
        ("frappe",    "Frappé",    "avares://CatppuccinThemePlugin/Themes/Frappe.axaml"),
        ("macchiato", "Macchiato", "avares://CatppuccinThemePlugin/Themes/Macchiato.axaml"),
        ("mocha",     "Mocha",     "avares://CatppuccinThemePlugin/Themes/Mocha.axaml"),
    };

    // The 25 semantic brush keys the host reads. Every palette must define
    // all of them, or a user selecting the theme meets an unstyled control.
    public static readonly string[] SemanticKeys =
    {
        // Surfaces
        "SidebarBackground", "ContentBackground", "PanelBackground1",
        "PanelBackground2", "PanelBackground3", "SubtleBorder",
        // Accents
        "PrimaryAccent", "PrimaryAccentHover", "OnPrimaryAccent", "SecondaryAccent",
        // Text
        "TextPrimary", "TextSecondary",
        // Status pairs
        "SuccessBackground", "SuccessForeground",
        "DangerBackground", "DangerForeground",
        "InfoBackground", "InfoForeground",
        "WarningBackground", "WarningForeground",
        // Composition
        "DropZoneHighlight", "WaveformBrush",
        "LoopInheritForeground", "LoopForceOnForeground", "LoopForceOffForeground",
    };

    public static IEnumerable<object[]> PaletteUris() =>
        Expected.Select(p => new object[] { p.Uri });

    public static IEnumerable<object[]> PaletteKeyMatrix() =>
        from p in Expected
        from key in SemanticKeys
        select new object[] { p.Uri, key };

    static IResourceDictionary LoadPalette(string uri)
    {
        var u = new Uri(uri);
        var include = new ResourceInclude(u) { Source = u };
        return include.Loaded;
    }

    [Fact]
    public void GetPalettes_returns_the_shipped_catalog()
    {
        var palettes = new CatppuccinThemePlugin().GetPalettes().ToArray();

        palettes.Select(p => (p.Id, p.Name, Uri: p.ResourceUris.Single()))
            .Should().Equal(Expected);
    }

    [AvaloniaTheory]
    [MemberData(nameof(PaletteUris))]
    public void Palette_resource_resolves_and_is_not_empty(string uri)
    {
        var dict = LoadPalette(uri);

        dict.Should().NotBeNull();
        dict.Count.Should().BeGreaterThan(0);
    }

    [AvaloniaTheory]
    [MemberData(nameof(PaletteKeyMatrix))]
    public void Palette_defines_every_semantic_key_as_a_brush(string uri, string key)
    {
        var dict = LoadPalette(uri);

        dict.TryGetResource(key, null, out var value)
            .Should().BeTrue($"palette '{uri}' must define '{key}'");
        value.Should().BeOfType<SolidColorBrush>();
    }

    [AvaloniaTheory]
    [MemberData(nameof(PaletteUris))]
    public void Palette_is_flat_with_no_theme_variant_dictionaries(string uri)
    {
        var dict = LoadPalette(uri);

        dict.ThemeDictionaries.Should().BeEmpty(
            $"palette '{uri}' must be a flat ResourceDictionary, not a Dark/Light variant model");
    }
}
