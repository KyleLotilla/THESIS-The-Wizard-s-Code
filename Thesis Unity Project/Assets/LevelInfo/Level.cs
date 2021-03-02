using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level 
{
    public int id;
    public string PathToLevelScene;
    public Dictionary<int, Material> materials;
    public Dictionary<int, Obstacles> obstacles;

}
