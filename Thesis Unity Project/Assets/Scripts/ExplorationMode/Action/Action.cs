using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Action : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Wizard { get; set; }

    public abstract void Execute();
    public abstract bool isFinishedExecuting();
}
