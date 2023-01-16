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
    partial class Program
    {

        /// <summary>
        /// Information for LCDs and other text surfaces.
        /// </summary>
        public class MyTextSurfaceInfo
        {

            /// <summary>
            /// Index of the <see cref="IMyTextSurface"/> in a <see cref="IMyTextSurfaceProvider"/> 
            /// or
            /// -1 when it is not a IMyTextSurfaceProvider (ie: <see cref="IMyTextPanel"/>).
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// Represents the item where write the text.
            /// </summary>
            public IMyTextSurface TextSurface { get; set; }

            /// <summary>
            /// Represents the block that contains the <see cref="TextSurface"/>.
            /// It can be the same object (ie: <see cref="IMyTextPanel"/>) or different (ie: <see cref="IMyTextSurfaceProvider"/>).
            /// </summary>
            public IMyTerminalBlock Owner { get; set; }

            /// <summary>
            /// Custom data required of the <see cref="TextSurface"/>.
            /// </summary>
            public string CustomData { get; set; }

        }

    }
}
