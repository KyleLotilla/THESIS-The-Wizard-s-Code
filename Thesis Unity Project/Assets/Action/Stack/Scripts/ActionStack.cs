using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Collections;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Actions.Stack
{
    public class ActionStack : MonoBehaviour
    {
        [SerializeField]
        private bool isRunning = true;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                ticks = 0.0f;
            }
        }

        public bool CanSpawn
        {
            get
            {
                return spawnableActionSpawnOptions.Count > 0;
            }
        }

        [SerializeField]
        private Vector2 actionSlotSpawnPositionOffset;
        [SerializeField]
        private float spawnRate;
        [SerializeField]
        private int nonCustomMaxSpawnedActions;
        [SerializeField]
        private IntVariable actionStackResetCount;
        [SerializeField]
        private UnityEvent onActionStackReset;
        [SerializeField]
        private List<ActionSpawnOptions> initialSpawnOptions;

        private SparseArray<ActionType, ActionSpawnOptions> spawnOptions;
        private Dictionary<ActionType, List<GameObject>> actionPrefabsMap;
        private SparseArray<ActionType, List<GameObject>> spawnedActions;
        private List<ActionSpawnOptions> spawnableActionSpawnOptions;
        private int spawnedNonCustomMaxCount = 0;
        private float ticks = 0.0f;

        private void Awake()
        {
            spawnOptions = new SparseArray<ActionType, ActionSpawnOptions>();
            actionPrefabsMap = new Dictionary<ActionType, List<GameObject>>();
            spawnedActions = new SparseArray<ActionType, List<GameObject>>();
            spawnableActionSpawnOptions = new List<ActionSpawnOptions>();

            foreach (ActionSpawnOptions spawnOption in initialSpawnOptions)
            {
                AddActionSpawnOptions(spawnOption);
            }
        }

        void Update()
        {
            if (isRunning)
            {
                ticks += Time.deltaTime;
                if (ticks >= spawnRate && CanSpawn)
                {
                    SpawnRandomAction();
                    ticks = 0.0f;
                }
            }
        }

        private void AddToSpawnablesListIfSpawnable(ActionType actionType)
        {
            ActionSpawnOptions actionSpawnOptions = spawnOptions[actionType];
            List<GameObject> actionPrefabsOfTargetType = actionPrefabsMap[actionSpawnOptions.TargetActionType];
            if (!spawnableActionSpawnOptions.Contains(actionSpawnOptions))
            {
                if (actionPrefabsOfTargetType.Count > 0)
                {
                    if (actionSpawnOptions.HasCustomMaxSpawnedActions)
                    {
                        List<GameObject> spawnedActionOfTargetType = spawnedActions[actionSpawnOptions.TargetActionType];
                        if (spawnedActionOfTargetType.Count < actionSpawnOptions.MaxSpawnedActions)
                        {
                            spawnableActionSpawnOptions.Add(actionSpawnOptions);
                        }
                    }
                    else if (spawnedNonCustomMaxCount < nonCustomMaxSpawnedActions)
                    {
                        spawnableActionSpawnOptions.Add(actionSpawnOptions);
                    }
                }
            }
        }

        private void AddEverySpawnableToSpawnableList()
        {
            foreach(ActionSpawnOptions spawnOption in spawnOptions)
            {
                AddToSpawnablesListIfSpawnable(spawnOption.TargetActionType);
            }
        }

        private void AddNonCustomMaxToSpawnablesListIfSpawnable()
        {
            foreach (ActionSpawnOptions spawnOption in spawnOptions)
            {
                if (!spawnOption.HasCustomMaxSpawnedActions)
                {
                    AddToSpawnablesListIfSpawnable(spawnOption.TargetActionType);
                }
            }
        }

        private void RemoveFromSpawnablesListIfNotSpawnable(ActionType actionType)
        {
            ActionSpawnOptions actionSpawnOptions = spawnOptions[actionType];
            List<GameObject> actionPrefabsOfTargetType = actionPrefabsMap[actionSpawnOptions.TargetActionType];
            if (actionPrefabsOfTargetType.Count <= 0)
            {
                spawnableActionSpawnOptions.Remove(actionSpawnOptions);
            }
            else
            {
                if (actionSpawnOptions.HasCustomMaxSpawnedActions)
                {
                    List<GameObject> spawnedActionOfTargetType = spawnedActions[actionSpawnOptions.TargetActionType];
                    if (spawnedActionOfTargetType.Count >= actionSpawnOptions.MaxSpawnedActions)
                    {
                        spawnableActionSpawnOptions.Remove(actionSpawnOptions);
                    }
                }
                else if (spawnedNonCustomMaxCount >= nonCustomMaxSpawnedActions)
                {
                    spawnableActionSpawnOptions.Remove(actionSpawnOptions);
                }
            }
        }

        private void RemoveNonCustomMaxFromSpawnableListIfNotSpawnable()
        {
            foreach (ActionSpawnOptions spawnOption in spawnOptions)
            {
                if (!spawnOption.HasCustomMaxSpawnedActions)
                {
                    RemoveFromSpawnablesListIfNotSpawnable(spawnOption.TargetActionType);
                }
            }
        }

        public void AddActionSpawnOptions(ActionSpawnOptions actionSpawnOptions)
        {
            ActionType actionType = actionSpawnOptions.TargetActionType;
            spawnedActions[actionType] = new List<GameObject>();
            spawnOptions[actionType] = actionSpawnOptions;
            actionPrefabsMap[actionType] = new List<GameObject>();
        }

        public void AddActionPrefabsToStack(ActionType actionType, List<GameObject> actionSlotPrefabs)
        {
            Debug.Assert(actionPrefabsMap.ContainsKey(actionType), name + ": No Action Spawn Options initialized for Type \"" + actionType.ToString() + "\"");
            if (actionPrefabsMap.ContainsKey(actionType))
            {
                actionPrefabsMap[actionType].AddRange(actionSlotPrefabs);
                AddToSpawnablesListIfSpawnable(actionType);
            }
        }

        public void SpawnRandomAction()
        {
            float sumChance = 0.0f;
            foreach (ActionSpawnOptions spawnOption in spawnableActionSpawnOptions)
            {
                sumChance += spawnOption.SpawnChance;
            }
            Vector2 chanceRange = new Vector2(0.0f, 0.0f);
            float rand = Random.Range(0.0f, sumChance);
            ActionType chosenActionTypeToSpawn = ActionType.NONE;
            foreach (ActionSpawnOptions spawnOption in spawnableActionSpawnOptions)
            {
                chanceRange.y = chanceRange.x + spawnOption.SpawnChance;
                if (rand >= chanceRange.x && rand <= chanceRange.y)
                {
                    chosenActionTypeToSpawn = spawnOption.TargetActionType;
                    break;
                }
                chanceRange.x = chanceRange.y;
            }
            SpawnRandomAction(chosenActionTypeToSpawn);
        }

        public void SpawnRandomAction(ActionType actionType)
        {
            if (actionType != ActionType.NONE)
            {
                List<GameObject> actionPrefabsOfActionType = actionPrefabsMap[actionType];
                int rand = Random.Range(0, actionPrefabsOfActionType.Count);
                SpawnAction(actionPrefabsOfActionType[rand]);
            }
        }

        public GameObject SpawnAction(GameObject actionPrefab)
        {
            GameObject actionObject = Instantiate(actionPrefab, this.transform);
            if (actionObject != null)
            {
                if (!actionObject.activeSelf)
                {
                    actionObject.SetActive(true);
                }
                ActionHolder actionHolder = actionObject.GetComponent<ActionHolder>();
                if (actionHolder != null)
                {
                    ActionType actionType = actionHolder.Action.ActionType;
                    spawnedActions[actionType].Add(actionObject);
                    ActionSpawnOptions spawnOption = spawnOptions[actionType];
                    if (!spawnOption.HasCustomMaxSpawnedActions)
                    {
                        spawnedNonCustomMaxCount++;
                        RemoveNonCustomMaxFromSpawnableListIfNotSpawnable();
                    }
                    else
                    {
                        RemoveFromSpawnablesListIfNotSpawnable(actionType);
                    }
                }
                RectTransform rectTransform = actionObject.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchorMin = new Vector2(0.5f, 1.0f);
                    rectTransform.anchorMax = new Vector2(0.5f, 1.0f);
                    rectTransform.anchoredPosition = actionSlotSpawnPositionOffset;
                }
                return actionObject;
            }
            else
            {
                return null;
            }
        }

        public void RemoveSpawnedActionFromStack(GameObject actionObject)
        {
            if (actionObject != null)
            {
                ActionHolder actionHolderToRemove = actionObject.GetComponent<ActionHolder>();
                Debug.Assert(actionHolderToRemove != null, name + ": Spawned Action has no Action Holder");
                if (actionHolderToRemove != null)
                {
                    Action actionToRemove = actionHolderToRemove.Action;
                    Debug.Assert(actionToRemove != null, name + ": Spawned Action Holder has no Action");
                    ActionType actionTypeOfActionToRemove = actionToRemove.ActionType;
                    List<GameObject> spawnedActionsOfActionTypeToRemoveFrom = spawnedActions[actionTypeOfActionToRemove];
                    bool isRemoved = spawnedActionsOfActionTypeToRemoveFrom.Remove(actionObject);

                    if (isRemoved)
                    {
                        ActionSpawnOptions spawnOption = spawnOptions[actionTypeOfActionToRemove];
                        if (!spawnOption.HasCustomMaxSpawnedActions)
                        {
                            spawnedNonCustomMaxCount--;
                            AddNonCustomMaxToSpawnablesListIfSpawnable();
                        }
                        else
                        {
                            AddToSpawnablesListIfSpawnable(actionTypeOfActionToRemove);
                        }
                        Destroy(actionObject);
                    }
                }
            }
        }

        public bool HasGameObjectAsSpawnedAction(GameObject actionObject)
        {
            ActionHolder actionHolder = actionObject.GetComponent<ActionHolder>();
            if (actionHolder != null)
            {
                Action action = actionHolder.Action;
                if (action != null)
                {
                    ActionType actionType = action.ActionType;
                    List<GameObject> spawnedActionsOfActionType = spawnedActions[actionType];
                    if (spawnedActionsOfActionType != null)
                    {
                        return spawnedActionsOfActionType.Contains(actionObject);
                    }
                }
            }
            return false;
        }

        public void ResetStack()
        {
            if (actionStackResetCount.Value > 0)
            {
                foreach (List<GameObject> spawnActionList in spawnedActions)
                {
                    foreach (GameObject spawnAction in spawnActionList)
                    {
                        Destroy(spawnAction);
                    }
                    spawnActionList.Clear();
                }
                spawnedNonCustomMaxCount = 0;
                actionStackResetCount.Value--;
                spawnableActionSpawnOptions.Clear();
                onActionStackReset?.Invoke();
                AddEverySpawnableToSpawnableList();
            }
        }
    }
}

