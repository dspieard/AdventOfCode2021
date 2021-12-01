using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class Submarine : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 newPos = new Vector3(0f, 4.0125f, 0f);
    int totalIncreased = 0;
    int totalIncreased2 = 0;
    int previousDepth = 157;
    public Text count;
    public Text count2;
    private int[] _lines;


    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.streamingAssetsPath + "/" + "day1" + ".txt";
        var linesInFile = File.ReadAllLines(filePath);
        _lines = Array.ConvertAll(linesInFile, int.Parse);
        StartCoroutine("DoStuffWithFileCoroutine", _lines);

        int sum = _lines[0] + _lines[1] + _lines[2];

        for (int i = 1; i < _lines.Length; i++)
        {
            if (i < 3)
                continue;

            int nextSum = sum - _lines[i - 3] + _lines[i];
            if (nextSum > sum)
                totalIncreased2++;
            sum = nextSum;
        }

        count2.text = "Part 2: " + totalIncreased2.ToString();
    }

    IEnumerator DoStuffWithFileCoroutine(int[] _lines)
    {
        
        foreach (int line in _lines)
        {
            if (line > previousDepth)
                totalIncreased++;
            previousDepth = line;
            float ypos = (transform.position.y - (line / 1000000.000f));
            newPos = new Vector3(transform.position.x, ypos, transform.position.z);
            transform.position = newPos;
            count.text = "Part 1: " + totalIncreased.ToString();
            yield return new WaitForSeconds(0.0000f);
        }
    }

}
