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
    static class CommonExtensions
    {

        public static IList<IMyTerminalBlock> GetBlocks(this IMyBlockGroup blockGroup)
        {
            var blocks = new List<IMyTerminalBlock>();

            blockGroup.GetBlocks(blocks);
            return blocks;
        }

        public static IList<T> GetBlocksOfType<T>(this IMyBlockGroup blockGroup, Func<T, bool> collect = null) where T : class
        {
            var blocks = new List<T>();

            blockGroup.GetBlocksOfType(blocks, collect);
            return blocks;
        }

        public static IList<IMyTerminalBlock> GetBlocks(this IMyGridTerminalSystem gridTerminalSystem)
        {
            var blocks = new List<IMyTerminalBlock>();

            gridTerminalSystem.GetBlocks(blocks);
            return blocks;
        }

        public static IList<T> GetBlocksOfType<T>(this IMyGridTerminalSystem gridTerminalSystem, Func<T, bool> collect = null) where T : class
        {
            var blocks = new List<T>();

            gridTerminalSystem.GetBlocksOfType(blocks, collect);
            return blocks;
        }

        public static IList<IMyBlockGroup> GetBlockGroups(this IMyGridTerminalSystem gridTerminalSystem, Func<IMyBlockGroup, bool> collect = null)
        {
            var blockGroups = new List<IMyBlockGroup>();

            gridTerminalSystem.GetBlockGroups(blockGroups, collect);
            return blockGroups;
        }

        /// <summary>
        /// Get all terminal actions available for block.
        /// </summary>
        public static IList<ITerminalAction> GetActions(this IMyTerminalBlock block, Func<ITerminalAction, bool> collect = null)
        {
            var actions = new List<ITerminalAction>();

            block.GetActions(actions, collect);
            return actions;
        }

    }
}
