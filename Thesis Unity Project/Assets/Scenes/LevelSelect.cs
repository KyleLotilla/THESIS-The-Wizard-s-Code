using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XElement LoadFile = XElement.Load("Assets/Scenes/XML/levels.xml");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
