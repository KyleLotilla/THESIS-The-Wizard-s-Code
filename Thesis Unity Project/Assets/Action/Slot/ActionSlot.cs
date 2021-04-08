using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnActionSlotDestroyed();

public class ActionSlot : MonoBehaviour
{
    public event OnActionSlotDestroyed OnActionSlotDestroyed;

    [SerializeField]
    private Image _icon;
    [SerializeField]
    public Image icon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
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
        Color color = _icon.color;
        color.a = 0.5f;
        _icon.color = color;
    }

    public void EnableSlot()
    {
        Color color = _icon.color;
        color.a = 1.0f;
        _icon.color = color;
    }

    private void OnDestroy()
    {
        OnActionSlotDestroyed?.Invoke();
        OnActionSlotDestroyed = null;
    }
}
