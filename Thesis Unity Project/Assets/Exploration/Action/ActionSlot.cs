using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnActionSlotDestroyed();

public class ActionSlot : MonoBehaviour
{
    public event OnActionSlotDestroyed OnActionSlotDestroyed;

    [SerializeField]
    private Image image;
    [SerializeReference]
    private Spell _spell;
    public Spell spell
    {
        get
        {
            return _spell;
        }
        set
        {
            _spell = value;
            if (_spell != null && image != null)
            {
                image.sprite = _spell.icon;
            }
        }
    }

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
        }
    }

    [SerializeField]
    private bool _isInQueue = false;
    public bool isInQueue
    {
        get
        {
            return _isInQueue;
        }
        set
        {
            _isInQueue = true;
        }
    }

    private void Start()
    {
    }

    public void DisableSlot()
    {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    public void EnableSlot()
    {
        Color color = image.color;
        color.a = 1.0f;
        image.color = color;
    }

    private void OnDestroy()
    {
        OnActionSlotDestroyed?.Invoke();
        OnActionSlotDestroyed = null;
    }
}
