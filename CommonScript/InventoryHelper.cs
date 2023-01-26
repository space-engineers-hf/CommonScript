﻿using Sandbox.Game.EntityComponents;
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

        public static IMyInventory[] GetInventories(this IMyTerminalBlock block)
        {
            var blockInventories = new List<IMyInventory>();

            if (block.HasInventory)
            {
                for (int i = 0; i < block.InventoryCount; i++)
                {
                    blockInventories.Add(block.GetInventory(i));
                }
            }
            return blockInventories.ToArray();
        }

    }
}
