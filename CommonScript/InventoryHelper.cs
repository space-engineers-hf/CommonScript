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
        /// Returns an inventory that can store an specific <see cref="MyItemType"/>
        /// </summary>
        public static IMyInventory TryGetInventory(this IMyTerminalBlock block, MyItemType itemType)
        {
            IMyInventory result = null;
            var acceptedItems = new List<MyItemType>();

            for (int i = 0; i < block.InventoryCount && result == null; i++)
            {
                var inventory = block.GetInventory(i);

                inventory.GetAcceptedItems(acceptedItems);
                if (acceptedItems.Contains(itemType))
                {
                    result = inventory;
                }
            }
            return result;
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
        /// Returns all items present inside this inventory and returns a snapshot of the current inventory state.
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

        /// <summary>
        /// Finds the specified item in a list of <see cref="IMyTerminalBlock"/>.
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="amount">Maximun quantity to search. Then the amount is found, it stops to search. Null for searching all.</param>
        /// <param name="targetInventory">Inventory to check if the item found can moves to it. Null for not checking.</param>
        /// <returns></returns>
        public static IEnumerable<MyInventoryItemResult> FindItem(this IEnumerable<IMyTerminalBlock> blocks, MyItemType itemType, MyFixedPoint? amount = null, IMyInventory targetInventory = null)
        {
            var list = new List<MyInventoryItemResult>();
            MyFixedPoint sum = 0;
            var etor = blocks.GetEnumerator();

            while (etor.MoveNext() && sum < amount)
            {
                list.AddRange(FindItem(etor.Current, itemType, ref sum, amount, targetInventory));
            }
            return list;
        }

        /// <summary>
        /// Find the specified item in a <see cref="IMyTerminalBlock"/>.
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="amount">Maximun quantity to search. Then the amount is found, it stops to search. Null for searching all.</param>
        /// <param name="targetInventory">Inventory to check if the item found can moves to it. Null for not checking.</param>
        /// <returns></returns>
        public static IEnumerable<MyInventoryItemResult> FindItem(this IMyTerminalBlock block, MyItemType itemType, MyFixedPoint? amount = null, IMyInventory targetInventory = null)
        {
            MyFixedPoint sum = 0;
            return FindItem(block, itemType, ref sum, amount, targetInventory);
        }

        /// <summary>
        /// Find the specified item in a <see cref="IMyTerminalBlock"/>.
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="amount">Maximun quantity to search. Then the amount is found, it stops to search. Null for searching all.</param>
        /// <param name="targetInventory">Inventory to check if the item found can moves to it. Null for not checking.</param>
        /// <returns></returns>
        public static IEnumerable<MyInventoryItemResult> FindItem(this IMyTerminalBlock block, MyItemType itemType, ref MyFixedPoint sum, MyFixedPoint? amount = null, IMyInventory targetInventory = null)
        {
            var list = new List<MyInventoryItemResult>();

            if (block.HasInventory)
            {
                var inventory = block.TryGetInventory(itemType);

                if (inventory != null && (targetInventory == null || inventory.CanTransferItemTo(targetInventory, itemType)))
                {
                    var itemNullable = inventory.FindItem(itemType);

                    if (itemNullable != null)
                    {
                        var item = (MyInventoryItem)itemNullable;

                        sum += item.Amount;
                        list.Add(new MyInventoryItemResult(inventory, item));
                    }
                }
            }
            return list;
        }

    }
}
