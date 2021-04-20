using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int levelID { get; set; }
    public int worldNum { get; set; }
    public int levelNum { get; set; }
    public string pathToLevel { get; set; }
    public List<int> materials { get; set; }
    public List<int> numMaterials { get; set; }
    public List<int> obstacles { get; set; }
    public List<int> numObstacles { get; set; }
    public string pathToLevelOverview { get; set; }
    public Sprite levelOverview { get; set; }
    public LevelProgression levelProgression { get; set; }
}
