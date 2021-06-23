using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int levelID { get; set; }
    public int worldNum { get; set; }
    public int levelNum { get; set; }
    public int sceneIndex { get; set; }
    public List<int> materials { get; set; }
    public List<int> numMaterials { get; set; }
    public List<ObstacleLevelInfo> obstacleLevelInfos;
    public List<int> unlockableSpellsIDs;
    public string pathToLevelOverview { get; set; }
    public Sprite levelOverview { get; set; }
    public int maximumScore { get; set; }
    public int starRequirement { get; set; }
}
