using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickup : MonoBehaviour
{
    [SerializeField]
    private MaterialPickupStorage materialPickupStorage;
    [SerializeField]
    private MaterialDatabase materialDatabase;
    [SerializeField]
    private int id;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = materialDatabase.GetMaterial(id);
        if (material != null)
        {
            spriteRenderer.sprite = material.icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wizard")
        {
            materialPickupStorage.AddMaterial(material);
            Destroy(this.gameObject);
        }
    }
}
