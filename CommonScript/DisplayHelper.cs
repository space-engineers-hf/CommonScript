using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    
        public static class DisplayHelper
        {

            /// <summary>
            /// Gets all LCD panels and terminal screens in the group.
            /// </summary>
            /// <remarks>
            /// Includes <see cref="IMyTextPanel"/> and <see cref="IMyTextSurfaceProvider"/> items.
            /// </remarks>
            public static IList<MyTextSurfaceInfo> GetTextSurfaces(IEnumerable<IMyTerminalBlock> blocks)
            {
                var result = new List<MyTextSurfaceInfo>();
                var panels = blocks.OfType<IMyTextPanel>();
                var surfaceProviders = blocks.OfType<IMyTextSurfaceProvider>();

                foreach (var panel in panels)
                {
                    result.Add(new MyTextSurfaceInfo
                    {
                        Index = -1,
                        Owner = panel,
                        TextSurface = panel,
                        CustomData = panel.CustomData
                    });
                }
                foreach (var provider in surfaceProviders)
                {
                    for (int i = 0; i < provider.SurfaceCount; i++)
                    {
                        var textSurface = provider.GetSurface(i);
                        var block = provider as IMyTerminalBlock;

                        result.Add(new MyTextSurfaceInfo
                        {
                            Index = i,
                            Owner = block,
                            TextSurface = textSurface,
                            CustomData = GetTextSurfaceCustomData(block.CustomData, i)
                        });
                    }
                }
                return result;
            }

            /// <summary>
            /// Gets all LCD panels and terminal screens in the group.
            /// </summary>
            /// <remarks>
            /// Includes <see cref="IMyTextPanel"/> and <see cref="IMyTextSurfaceProvider"/> items.
            /// </remarks>
            public static IList<MyTextSurfaceInfo> GetTextSurfaces(params IMyTerminalBlock[] blocks)
                => GetTextSurfaces((IEnumerable<IMyTerminalBlock>)blocks);

            /// <summary>
            /// Returns the custom data part of the specified index.
            /// </summary>
            public static string GetTextSurfaceCustomData(string customData, int index)
            {
                var result = string.Empty;
                var regex = new System.Text.RegularExpressions.Regex("@((?<index>[0-9]+) (?<script>\\w+))(?<content>[^@]*)"); // https://regex101.com/r/9fkwwx/1
                var matches = regex.Matches(customData);
                var match = matches
                    .OfType<System.Text.RegularExpressions.Match>()
                    .FirstOrDefault(x => x.Success && x.Groups["index"].Value == index.ToString());

                if (match != null)
                {
                    result = match.Groups["content"].Value.Trim();
                }
                return result;
            }

            /// <summary>
            /// Returns a string with the specified time split in days, hours and minutes.
            /// </summary>
            public static string FormatMinutes(float minutes)
            {
                return FormatTime(TimeSpan.FromMinutes(minutes));
            }

            /// <summary>
            /// Returns a string with the specified time split in days, hours and minutes.
            /// </summary>
            public static string FormatTime(TimeSpan timeSpan)
            {
                var text = new List<string>();

                if (timeSpan.Days > 0)
                {
                    text.Add($"{timeSpan.Days} day{(timeSpan.Days > 0 ? "s" : "")}");
                }
                if (timeSpan.Hours > 0)
                {
                    text.Add($"{timeSpan.Hours}h");
                }
                if (timeSpan.Minutes > 0)
                {
                    if (timeSpan.Days > 0 || timeSpan.Hours > 0 || timeSpan.Seconds > 0)
                    {
                        text.Add($"{timeSpan.Minutes}m");
                    }
                    else
                    {
                        text.Add($"{timeSpan.Minutes} minute{(timeSpan.Minutes > 0 ? "s" : "")}");
                    }
                }
                if (timeSpan.Seconds > 0)
                {
                    if (timeSpan.Days > 0 || timeSpan.Hours > 0 || timeSpan.Minutes > 0)
                    {
                        text.Add($"{timeSpan.Seconds}s");
                    }
                    else
                    {
                        text.Add($"{timeSpan.Seconds} second{(timeSpan.Seconds > 0 ? "s" : "")}");
                    }
                }
                return string.Join(" ", text);
            }

    }
}
