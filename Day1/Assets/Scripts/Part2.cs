using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class Part2 : MonoBehaviour
{
    int totalIncreased = 0;
    private int[] _lines;
    // Start is called before the first frame update
    void Start()
    {
        var filePath = Application.streamingAssetsPath + "/" + "day1" + ".txt";
        var linesInFile = File.ReadAllLines(filePath);
        _lines = Array.ConvertAll(linesInFile, int.Parse);

        int sum = _lines[0]+_lines[1]+_lines[2];

        for (int i = 1; i < _lines.Length; i++)
        {
            if (i < 3)
                continue;

            int nextSum = sum - _lines[i - 3] + _lines[i];
            if (nextSum > sum)
                totalIncreased++;
            sum = nextSum;
        }

        Debug.Log(totalIncreased);

    }
     

}
