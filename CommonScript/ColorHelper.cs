using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRage;
using VRageMath;
using System.Collections.Immutable;

namespace IngameScript
{

    public static class ColorHelper
    {

        static IDictionary<string, Color?> Colors = new Dictionary<string, Color?>(StringComparer.OrdinalIgnoreCase)
        {
            { "Transparent", Color.Transparent },
            { "AliceBlue", Color.AliceBlue },
            { "AntiqueWhite", Color.AntiqueWhite },
            { "Aqua", Color.Aqua },
            { "Aquamarine", Color.Aquamarine },
            { "Azure", Color.Azure },
            { "Beige", Color.Beige },
            { "Bisque", Color.Bisque },
            { "Black", Color.Black },
            { "BlanchedAlmond", Color.BlanchedAlmond },
            { "Blue", Color.Blue },
            { "BlueViolet", Color.BlueViolet },
            { "Brown", Color.Brown },
            { "BurlyWood", Color.BurlyWood },
            { "CadetBlue", Color.CadetBlue },
            { "Chartreuse", Color.Chartreuse },
            { "Chocolate", Color.Chocolate },
            { "Coral", Color.Coral },
            { "CornflowerBlue", Color.CornflowerBlue },
            { "Cornsilk", Color.Cornsilk },
            { "Crimson", Color.Crimson },
            { "Cyan", Color.Cyan },
            { "DarkBlue", Color.DarkBlue },
            { "DarkCyan", Color.DarkCyan },
            { "DarkGoldenrod", Color.DarkGoldenrod },
            { "DarkGray", Color.DarkGray },
            { "DarkGreen", Color.DarkGreen },
            { "DarkKhaki", Color.DarkKhaki },
            { "DarkMagenta", Color.DarkMagenta },
            { "DarkOliveGreen", Color.DarkOliveGreen },
            { "DarkOrange", Color.DarkOrange },
            { "DarkOrchid", Color.DarkOrchid },
            { "DarkRed", Color.DarkRed },
            { "DarkSalmon", Color.DarkSalmon },
            { "DarkSeaGreen", Color.DarkSeaGreen },
            { "DarkSlateBlue", Color.DarkSlateBlue },
            { "DarkSlateGray", Color.DarkSlateGray },
            { "DarkTurquoise", Color.DarkTurquoise },
            { "DarkViolet", Color.DarkViolet },
            { "DeepPink", Color.DeepPink },
            { "DeepSkyBlue", Color.DeepSkyBlue },
            { "DimGray", Color.DimGray },
            { "DodgerBlue", Color.DodgerBlue },
            { "Firebrick", Color.Firebrick },
            { "FloralWhite", Color.FloralWhite },
            { "ForestGreen", Color.ForestGreen },
            { "Fuchsia", Color.Fuchsia },
            { "Gainsboro", Color.Gainsboro },
            { "GhostWhite", Color.GhostWhite },
            { "Gold", Color.Gold },
            { "Goldenrod", Color.Goldenrod },
            { "Gray", Color.Gray },
            { "Green", Color.Green },
            { "GreenYellow", Color.GreenYellow },
            { "Honeydew", Color.Honeydew },
            { "HotPink", Color.HotPink },
            { "IndianRed", Color.IndianRed },
            { "Indigo", Color.Indigo },
            { "Ivory", Color.Ivory },
            { "Khaki", Color.Khaki },
            { "Lavender", Color.Lavender },
            { "LavenderBlush", Color.LavenderBlush },
            { "LawnGreen", Color.LawnGreen },
            { "LemonChiffon", Color.LemonChiffon },
            { "LightBlue", Color.LightBlue },
            { "LightCoral", Color.LightCoral },
            { "LightCyan", Color.LightCyan },
            { "LightGoldenrodYellow", Color.LightGoldenrodYellow },
            { "LightGray", Color.LightGray },
            { "LightGreen", Color.LightGreen },
            { "LightPink", Color.LightPink },
            { "LightSalmon", Color.LightSalmon },
            { "LightSeaGreen", Color.LightSeaGreen },
            { "LightSkyBlue", Color.LightSkyBlue },
            { "LightSlateGray", Color.LightSlateGray },
            { "LightSteelBlue", Color.LightSteelBlue },
            { "LightYellow", Color.LightYellow },
            { "Lime", Color.Lime },
            { "LimeGreen", Color.LimeGreen },
            { "Linen", Color.Linen },
            { "Magenta", Color.Magenta },
            { "Maroon", Color.Maroon },
            { "MediumAquamarine", Color.MediumAquamarine },
            { "MediumBlue", Color.MediumBlue },
            { "MediumOrchid", Color.MediumOrchid },
            { "MediumPurple", Color.MediumPurple },
            { "MediumSeaGreen", Color.MediumSeaGreen },
            { "MediumSlateBlue", Color.MediumSlateBlue },
            { "MediumSpringGreen", Color.MediumSpringGreen },
            { "MediumTurquoise", Color.MediumTurquoise },
            { "MediumVioletRed", Color.MediumVioletRed },
            { "MidnightBlue", Color.MidnightBlue },
            { "MintCream", Color.MintCream },
            { "MistyRose", Color.MistyRose },
            { "Moccasin", Color.Moccasin },
            { "NavajoWhite", Color.NavajoWhite },
            { "Navy", Color.Navy },
            { "OldLace", Color.OldLace },
            { "Olive", Color.Olive },
            { "OliveDrab", Color.OliveDrab },
            { "Orange", Color.Orange },
            { "OrangeRed", Color.OrangeRed },
            { "Orchid", Color.Orchid },
            { "PaleGoldenrod", Color.PaleGoldenrod },
            { "PaleGreen", Color.PaleGreen },
            { "PaleTurquoise", Color.PaleTurquoise },
            { "PaleVioletRed", Color.PaleVioletRed },
            { "PapayaWhip", Color.PapayaWhip },
            { "PeachPuff", Color.PeachPuff },
            { "Peru", Color.Peru },
            { "Pink", Color.Pink },
            { "Plum", Color.Plum },
            { "PowderBlue", Color.PowderBlue },
            { "Purple", Color.Purple },
            { "Red", Color.Red },
            { "RosyBrown", Color.RosyBrown },
            { "RoyalBlue", Color.RoyalBlue },
            { "SaddleBrown", Color.SaddleBrown },
            { "Salmon", Color.Salmon },
            { "SandyBrown", Color.SandyBrown },
            { "SeaGreen", Color.SeaGreen },
            { "SeaShell", Color.SeaShell },
            { "Sienna", Color.Sienna },
            { "Silver", Color.Silver },
            { "SkyBlue", Color.SkyBlue },
            { "SlateBlue", Color.SlateBlue },
            { "SlateGray", Color.SlateGray },
            { "Snow", Color.Snow },
            { "SpringGreen", Color.SpringGreen },
            { "SteelBlue", Color.SteelBlue },
            { "Tan", Color.Tan },
            { "Teal", Color.Teal },
            { "Thistle", Color.Thistle },
            { "Tomato", Color.Tomato },
            { "Turquoise", Color.Turquoise },
            { "Violet", Color.Violet },
            { "Wheat", Color.Wheat },
            { "White", Color.White },
            { "WhiteSmoke", Color.WhiteSmoke },
            { "Yellow", Color.Yellow },
            { "YellowGreen", Color.YellowGreen }
        };


        public static Color? FromName(string name)
        {
            Color? color;

            Colors.TryGetValue(name, out color);
            return color;
        }

        public static Color? FromHtml(string htmlColor)
        {
            return ColorExtensions.FromHtml(htmlColor);
        }

        public static Color? FromRGB(int r, int g, int b)
        {
            return new Color(r, g, b);
        }

        public static Color? FromARGB(int a, int r, int g, int b)
        {
            return new Color(r, g, b, a);
        }

    }
}
