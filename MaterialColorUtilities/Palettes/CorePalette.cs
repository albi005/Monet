﻿using MaterialColorUtilities.ColorAppearance;

namespace MaterialColorUtilities.Palettes;

/**
 * An intermediate concept between the key color for a UI theme, and a full color scheme. 5 sets of
 * tones are generated, all except one use the same hue as the key color, and all vary in chroma.
 */
public class CorePalette
{
    public TonalPalette Primary { get; set; }
    public TonalPalette Secondary { get; set; }
    public TonalPalette Tertiary { get; set; }
    public TonalPalette Neutral { get; set; }
    public TonalPalette NeutralVariant { get; set; }
    public TonalPalette Error { get; set; }

    /**
     * Create key tones from a color.
     *
     * @param argb ARGB representation of a color
     */
    public static CorePalette Of(int seed) => new(seed);

    public CorePalette(int seed)
    {
        Hct hct = Hct.FromInt(seed);
        double hue = hct.Hue;
        Primary = TonalPalette.FromHueAndChroma(hue, Math.Max(48, hct.Chroma));
        Secondary = TonalPalette.FromHueAndChroma(hue, 16);
        Tertiary = TonalPalette.FromHueAndChroma(hue + 60, 24);
        Neutral = TonalPalette.FromHueAndChroma(hue, 4);
        NeutralVariant = TonalPalette.FromHueAndChroma(hue, 8);
        Error = TonalPalette.FromHueAndChroma(25, 84);
    }
}
