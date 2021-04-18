using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerProfile")]
public class PlayerProfile : ScriptableObject
{
    public string playerName;
    public Gender gender;
}
