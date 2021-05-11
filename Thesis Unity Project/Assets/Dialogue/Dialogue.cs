using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public int id;
    private List<string> lines;

    public Dialogue()
    {
        id = 0;
        lines = new List<string>();
    }
    public int lineCount
    {
        get
        {
            return lines.Count;
        }
    }

    public void AddLine(string line)
    {
        lines.Add(line);
    }

    public string GetLine(int lineNum)
    {
        if (lineNum >= 0 && lineNum < lines.Count)
        {
            return lines[lineNum];
        }
        else
        {
            return null;
        }
    }
}
