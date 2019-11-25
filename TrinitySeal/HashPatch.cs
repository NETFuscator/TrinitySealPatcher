using System;
using System.Collections.Generic;
using System.Text;

using HarmonyLib;

namespace TrinitySeal {
    [HarmonyPatch(typeof(string), "op_Inequality", new Type[] { typeof(string), typeof(string) })]
    public class HashPatch {
        internal static void Prefix(ref string a, ref string b) {
            var index = _hashes.IndexOf(b);

            if (index != -1)
                a = _hashes[index];
        }

        public static void ApplyHook() {
            _instance = new Harmony("jebany.trinitysealpatch");
            _instance.PatchAll();
        }

        internal static List<string> _hashes = new List<string> {
            "4df6c8781e70c3a4912b5be796e6d337",
            "0788cb32d5eb03916c701e0d18e25a74",
        };

        private static Harmony _instance = null;
    }
}
