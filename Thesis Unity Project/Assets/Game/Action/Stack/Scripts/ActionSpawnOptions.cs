using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions.Stack
{
    [Serializable]
    public class ActionSpawnOptions
    {
        [SerializeField]
        private ActionType targetActionType;
        public ActionType TargetActionType
        {
            get
            {
                return targetActionType;
            }
            set
            {
                targetActionType = value;
            }
        }

        [Range(0.0f, 100.0f)]
        [SerializeField]
        private float spawnChance;
        public float SpawnChance
        {
            get
            {
                return spawnChance;
            }
            set
            {
                spawnChance = value;
            }
        }

        [SerializeField]
        private bool hasCustomMaxSpawnedActions = false;

        public bool HasCustomMaxSpawnedActions
        {
            get
            {
                return hasCustomMaxSpawnedActions;
            }
            set
            {
                hasCustomMaxSpawnedActions = value;
            }
        }

        [Min(1)]
        [SerializeField]
        private int maxSpawnedActions;

        public int MaxSpawnedActions
        {
            get
            {
                return maxSpawnedActions;
            }
            set
            {
                maxSpawnedActions = value;
            }
        }
    }

}
