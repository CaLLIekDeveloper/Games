// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyGame;
namespace MainStatic{
    public static class Main {

        public static DragAndDrop dragAndDrop { get; set; }
        public static Chess chess { get; set; }
        public static ScriptBoard scriptBoard { get; set; }

        public static String previousMove { get; set; }
        public static int CountSteps { get; set; }
        public static StockFish stockFish { get; set; }

        public static string NowScene { get; set; }
        public static Player player { get; set; }
    }
}
