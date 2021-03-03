using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickupStorage : MonoBehaviour, IEnumerable
{
    [SerializeField]
    private List<Material> materials;

    // Start is called before the first frame update
    void Start()
    {
        materials = new List<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaterial(Material material)
    {
        materials.Add(material);
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)materials).GetEnumerator();
    }
}
