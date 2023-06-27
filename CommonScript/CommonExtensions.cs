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

        /// <summary>
        /// Get terminal blocks which assigned to this group.
        /// </summary>
        /// <param name="blockGroup">The block group of the blocks.</param>
        /// <param name="collect">if function returns true, block would be added to blocks.</param>
        /// <returns>A list with the terminal blocks assigned to this group.</returns>
        public static IList<IMyTerminalBlock> GetBlocks(this IMyBlockGroup blockGroup, Func<IMyTerminalBlock, bool> collect = null)
        {
            var blocks = new List<IMyTerminalBlock>();

            blockGroup.GetBlocks(blocks, collect);
            return blocks;
        }

        /// <summary>
        /// Get terminal blocks which assigned to this group, and matching type.
        /// </summary>
        /// <typeparam name="T">Block must be assignable from T.</typeparam>
        /// <param name="blockGroup">The block group of the blocks.</param>
        /// <param name="collect">if function returns true, block would be added to blocks.</param>
        /// <returns>A list with the terminal blocks assigned to this group.</returns>
        public static IList<T> GetBlocksOfType<T>(this IMyBlockGroup blockGroup, Func<T, bool> collect = null) where T : class
        {
            var blocks = new List<T>();

            blockGroup.GetBlocksOfType(blocks, collect);
            return blocks;
        }

        /// <summary>
        /// Returns a list with the blocks reachable by this grid terminal system.
        /// This means all blocks on the same grid, or connected via rotors, pistons or connectors.
        /// </summary>
        /// <param name="gridTerminalSystem">The terminal server of the blocks.</param>
        /// <returns>A list with the blocks.</returns>
        public static IList<IMyTerminalBlock> GetBlocks(this IMyGridTerminalSystem gridTerminalSystem)
        {
            var blocks = new List<IMyTerminalBlock>();

            gridTerminalSystem.GetBlocks(blocks);
            return blocks;
        }

        /// <summary>
        /// Returns a list with the blocks reachable by this grid terminal system.
        /// This means all blocks on the same grid, or connected via rotors, pistons or connectors.
        /// </summary>
        /// <typeparam name="T">The type of blocks to retrieve.</typeparam>
        /// <param name="gridTerminalSystem">The terminal server of the blocks.</param>
        /// <param name="collect">Provide a filter method to determine if a given group should be added or not.</param>
        /// <returns>A list with the blocks.</returns>
        public static IList<T> GetBlocksOfType<T>(this IMyGridTerminalSystem gridTerminalSystem, Func<T, bool> collect = null) where T : class
        {
            var blocks = new List<T>();

            gridTerminalSystem.GetBlocksOfType(blocks, collect);
            return blocks;
        }

        /// <summary>
        /// Gets the block groups reachable by this grid terminal system.
        /// </summary>
        /// <param name="gridTerminalSystem">The terminal server of the block groups.</param>
        /// <param name="collect">Provide a filter method to determine if a given group should be added or not.</param>
        /// <returns>A list with the block groups.</returns>
        public static IList<IMyBlockGroup> GetBlockGroups(this IMyGridTerminalSystem gridTerminalSystem, Func<IMyBlockGroup, bool> collect = null)
        {
            var blockGroups = new List<IMyBlockGroup>();

            gridTerminalSystem.GetBlockGroups(blockGroups, collect);
            return blockGroups;
        }

        /// <summary>
        /// Gets the block groups where the <see cref="IMyTerminalBlock"/> is in.
        /// </summary>
        /// <param name="gridTerminalSystem">The terminal server of the block groups.</param>
        /// <param name="block">The terminal block to find in the block groups.</param>
        /// <param name="collect">Provide a filter method to determine if a given group should be added or not.</param>
        /// <returns>A list with the block groups.</returns>
        public static IList<IMyBlockGroup> GetBlockGroups(this IMyGridTerminalSystem gridTerminalSystem, IMyTerminalBlock block, Func<IMyBlockGroup, bool> collect = null)
        {
            Func<IMyBlockGroup, bool> basicPredicate = x => x.GetBlocks().Any(y => y == block);
            Func<IMyBlockGroup, bool> predicate;

            if (collect == null)
            {
                predicate = basicPredicate;
            }
            else
            {
                predicate = x => basicPredicate(x) && collect(x);
            }
            return GetBlockGroups(gridTerminalSystem, predicate);
        }

        /// <summary>
        /// Gets all terminal actions available for block.
        /// </summary>
        public static IList<ITerminalAction> GetActions(this IMyTerminalBlock block, Func<ITerminalAction, bool> collect = null)
        {
            var actions = new List<ITerminalAction>();

            block.GetActions(actions, collect);
            return actions;
        }

    }
}
