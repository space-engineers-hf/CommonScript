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

    /// <summary>
    /// Information about the <see cref="MyInventoryItem"/> and the <see cref="IMyInventory"/> where it is in.
    /// </summary>
    public class MyInventoryItemResult
    {

        public IMyInventory Inventory { get; }
        public MyInventoryItem Item { get; }

        internal MyInventoryItemResult(IMyInventory inventory, MyInventoryItem item)
        {
            this.Inventory = inventory;
            this.Item = item;
        }
    }

}
