﻿using UnityEngine;

namespace Venly.Editor.Utils
{
    internal static class VenlyDebugEd
    {
        public static bool EnableDebugLog { get; set; } = true;
        public static int VerboseLevel { get; set; } = 0;

        public static void LogDebug(string msg, int verboseLevel = -1)
        {
            if (verboseLevel <= VerboseLevel)
                return;

            if(EnableDebugLog)
                Debug.Log(msg);
        }
    }
}
