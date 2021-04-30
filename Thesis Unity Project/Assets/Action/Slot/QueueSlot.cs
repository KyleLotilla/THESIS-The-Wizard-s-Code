using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSlot : MonoBehaviour
{
    private ActionSlot _stackSlot;
    public ActionSlot stackSlot
    {
        get
        {
            return _stackSlot;
        }
        set
        {
            _stackSlot = value;
            DestroyHandler destoryHandler = _stackSlot.GetComponent<DestroyHandler>();
            if (destoryHandler != null)
            {
                destoryHandler.OnGameObjectDestroy += OnStackSlotDestroy;
            }
        }
    }

    private void OnStackSlotDestroy()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
