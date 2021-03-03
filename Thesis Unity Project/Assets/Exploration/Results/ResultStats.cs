using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultStats : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, int> intDict;
    private Dictionary<string, float> floatDict;
    private Dictionary<string, string> stringDict;
    void Start()
    {
        intDict = new Dictionary<string, int>();
        floatDict = new Dictionary<string, float>();
        stringDict = new Dictionary<string, string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetInt(string statName)
    {
        if (intDict.ContainsKey(statName))
        {
            return intDict[statName];
        }
        else
        {
            return 0;
        }
    }

    public void SetInt(string statName, int value)
    {
        intDict[statName] = value;
    }

    public float GetFloat(string statName)
    {
        if (floatDict.ContainsKey(statName))
        {
            return floatDict[statName];
        }
        else
        {
            return 0.0f;
        }
    }

    public void SetFloat(string statName, float value)
    {
        floatDict[statName] = value;
    }

    public string GetString(string statName)
    {
        if (stringDict.ContainsKey(statName))
        {
            return stringDict[statName];
        }
        else
        {
            return "";
        }
    }

    public void SetString(string statName, string value)
    {
        stringDict[statName] = value;
    }
}
