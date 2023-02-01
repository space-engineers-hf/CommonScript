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

    public static class InventoryHelper
    {

        /// <summary>
        /// Search for all inventories of the entity.
        /// </summary>
        public static IList<IMyInventory> GetInventories(this IMyTerminalBlock block)
        {
            var blockInventories = new List<IMyInventory>();

            if (block.HasInventory)
            {
                for (int i = 0; i < block.InventoryCount; i++)
                {
                    blockInventories.Add(block.GetInventory(i));
                }
            }
            return blockInventories;
        }

        /// <summary>
        /// Returns all items this inventory accepts.
        /// </summary>
        public static IList<MyItemType> GetAcceptedItems(this IMyInventory inventory, Func<MyItemType, bool> filter = null)
        {
            var types = new List<MyItemType>();

            inventory.GetAcceptedItems(types, filter);
            return types;
        }

        /// <summary>
        /// Returns all items present inside this inventory and returns snapshot of the current inventory state.
        /// </summary>
        public static IList<MyInventoryItem> GetItems(this IMyInventory inventory, Func<MyInventoryItem, bool> filter = null)
        {
            var items = new List<MyInventoryItem>();

            inventory.GetItems(items, filter);
            return items;
        }

        /// <summary>
        /// Returns all items present inside this inventory and returns snapshot of the current inventory state.
        /// </summary>
        public static IList<MyInventoryItem> GetItems(this IMyTerminalBlock block, Func<IMyInventory, bool> collect = null, Func<MyInventoryItem, bool> filter = null)
        {
            var items = new List<MyInventoryItem>();

            if (block.HasInventory)
            {
                for (int i = 0; i < block.InventoryCount; i++)
                {
                    var inventory = block.GetInventory(i);

                    if (collect == null || collect(inventory))
                    {
                        inventory.GetItems(items, filter);
                    }
                }
            }
            return items;
        }

    }
}
