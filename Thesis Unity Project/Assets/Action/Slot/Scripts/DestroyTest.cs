using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
    [SerializeField]
    private DestroyHandler destroyHandler;

    // Start is called before the first frame update
    void Start()
    {
        destroyHandler.OnGameObjectDestroy += OnGameObjectDestroy;
    }

    private void OnGameObjectDestroy()
    {
        Debug.Log(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
