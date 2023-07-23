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

    public static class CommonHelper
    {

        /// <summary>
        /// Gets if the process has been called periodically.
        /// </summary>
        public static bool IsCycle(UpdateType updateSource)
        {
            return (updateSource == UpdateType.Update1 || updateSource == UpdateType.Update10 || updateSource == UpdateType.Update100 || updateSource == UpdateType.Once);
        }

        /// <summary>
        /// Gets if two arrays contains the same elements and in the same order.
        /// </summary>
        public static bool ArrayEquals<TValue>(IEnumerable<TValue> value1, IEnumerable<TValue> value2)
        {
            if (value1 == null && value2 == null)
            {
                return true;
            }
            else if (value1 == null || value2 == null)
            {
                return false;
            }
            else
            {
                var etor1 = value1.GetEnumerator();
                var etor2 = value2.GetEnumerator();
                var pend1 = true;
                var pend2 = true;
                var equals = true;

                while (equals && pend1 && pend2)
                {
                    pend1 = etor1.MoveNext();
                    pend2 = etor2.MoveNext();

                    if (pend1 && pend2)
                    {
                        equals = object.Equals(etor1.Current, etor2.Current);
                    }
                }
                return !pend1 && !pend2 && equals;
            }
        }

    }
}
