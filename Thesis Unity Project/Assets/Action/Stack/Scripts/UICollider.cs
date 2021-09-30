using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollider : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private BoxCollider2D boxcollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider2D.size = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
