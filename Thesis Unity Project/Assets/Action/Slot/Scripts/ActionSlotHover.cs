using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSlotHover : MonoBehaviour //IPointerEnterHandler, IPointerExitHandler
{
    private ExplorationHoverHandler _explorationHoverHandler;
    public ExplorationHoverHandler explorationHoverHandler
    {
        private get
        {
            return _explorationHoverHandler;
        }
        set
        {
            _explorationHoverHandler = value;
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
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        explorationHoverHandler.HandleHover(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        explorationHoverHandler.ClearCurrentHover();
    }
    */
}
