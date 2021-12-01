using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Submarine : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 newPos = new Vector3(0f, 4.0125f, 0f);
    int totalIncreased = 0;
    int previousDepth = 157;
    public Text count;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DoStuffWithFileCoroutine");
    }

    IEnumerator DoStuffWithFileCoroutine()
    {
        string filePath = Application.streamingAssetsPath + "/" + "day1" + ".txt";
        List<string> linesInFile = File.ReadAllLines(filePath).ToList();
        foreach (string line in linesInFile)
        {
            if (int.Parse(line) > previousDepth)
                totalIncreased++;
            previousDepth = int.Parse(line);
            float ypos = (transform.position.y - (int.Parse(line) / 1000000.000f));
            newPos = new Vector3(transform.position.x, ypos, transform.position.z);
            transform.position = newPos;
            count.text = totalIncreased.ToString();
            yield return new WaitForSeconds(0.001f);
        }
    }

}
