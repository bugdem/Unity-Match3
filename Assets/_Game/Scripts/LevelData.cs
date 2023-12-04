using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.Core
{
    [Serializable]
    public enum LevelLimitationType
    {
        Move = 0,
        Time = 1
    }

    [Serializable]
    public enum LevelTargetType
    {
        Collect = 0,
        Jam = 1
    }

    [Serializable]
    public class LevelTarget
    {
        public LevelTargetType TargetType;
        public string ElementId;
        public ushort Count;
    }


    [Serializable]
    public class LevelData
    {
        public uint Index;
        public string Name;
        public string Id;

        public LevelLimitationType Limitation;
        [EnableIf("LimitationType", LevelLimitationType.Move)]
        public ushort MoveCount = 30;
		[EnableIf("LimitationType", LevelLimitationType.Time)]
		public ushort TimeCounter = 60; // In seconds
        public List<LevelTarget> Targets;
    }
}