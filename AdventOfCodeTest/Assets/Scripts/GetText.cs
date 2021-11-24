using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class GetText : MonoBehaviour
{
    public Text textBox;
    int totalhash = 0;
    int totaldot = 0;
    void Start()
    {
        List<string> linesInFile = ReadFile("testfile");
        DoStuffWithFile(linesInFile);
        textBox.text = "hash: " + totalhash.ToString() + "\n dot: " + totaldot.ToString();
    }

    private void DoStuffWithFile(List<string> linesInFile)
    {
        foreach (string line in linesInFile)
        {
            foreach (char c in line)
            {
                if (c.ToString() == "#")
                {
                    totalhash += 1;
                }
                else if (c.ToString() == ".")
                {
                    totaldot += 1;
                }
            }
        }
    }

    private static List<string> ReadFile(string filename)
    {
        string filePath = Application.streamingAssetsPath + "/Files/" + filename + ".txt";
        List<string> linesInFile = File.ReadAllLines(filePath).ToList();
        return linesInFile;
    }
}
