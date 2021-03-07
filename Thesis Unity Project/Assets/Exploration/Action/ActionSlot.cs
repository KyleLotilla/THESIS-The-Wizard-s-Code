using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : DragSlot
{

    [SerializeField]
    private Image image;
    [SerializeField]
    private Action _action;
    public Action action
    {
        get
        {
            return _action;
        }
        set
        {
            _action = value;
            if (image != null)
            {
                image.sprite = _action.spell.icon;
            }
        }
    }

    public bool isInQueue { get; set; } = false;

    private void Start()
    {
        /*
        if (image != null && action != null)
        {
            image.sprite = action.spell.icon;
        }
        */
    }

    public void DisableSlot()
    {
        isDraggable = false;
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    public void EnableSlot()
    {
        isDraggable = true;
        Color color = image.color;
        color.a = 1.0f;
        image.color = color;
    }
}
