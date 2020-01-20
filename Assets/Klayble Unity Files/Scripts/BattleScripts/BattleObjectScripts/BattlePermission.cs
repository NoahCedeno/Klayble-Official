using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleObjectSystem
{
    public struct BattlePermission
    {
        [SerializeField]
        private bool m_CanPerform;
        public bool CanPerform { get => m_CanPerform; set => m_CanPerform = value; }

        [SerializeField]
        private bool m_CanReceive;
        public bool CanReceive { get => m_CanReceive; set => CanReceive = value; }
    }
}