using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    string[] lineArr;
    int vertical = 0;
    int horizontal = 0;
    int answer = 0;

    int vertical2 = 0;
    int horizontal2 = 0;
    int aim = 0;
    int answer2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.streamingAssetsPath + "/" + "day2" + ".txt";
        string[] linesInFile = File.ReadAllLines(filePath);

        StartCoroutine("DoStuffWithFileCoroutine", linesInFile);
        

        foreach (var line in linesInFile)
        {
            lineArr = line.Split(' ');
            string argument = lineArr[0];
            int movement = int.Parse(lineArr[1]);

            switch (argument)
            {
                case "forward":
                    horizontal2 += movement;
                    vertical2 += (movement * aim);
                    break;
                case "down":
                    aim += movement;
                    break;
                case "up":
                    aim -= movement;
                    break;
                default:
                    break;

            }
        }
        Debug.Log(vertical);
        Debug.Log(horizontal);
        answer = vertical * horizontal;
        Debug.Log(answer);

        Debug.Log(vertical2);
        Debug.Log(horizontal2);
        answer2 = vertical2 * horizontal2;
        Debug.Log(answer2);
    }

    IEnumerator DoStuffWithFileCoroutine(string[] linesInFile)
    {
        foreach (var line in linesInFile)
        {
            lineArr = line.Split(' ');
            string argument = lineArr[0];
            int movement = int.Parse(lineArr[1]);

            switch (argument)
            {
                case "forward":
                    horizontal += movement;
                    Debug.Log(transform.position);
                    transform.position = new Vector3((transform.position.x + movement), transform.position.y, transform.position.z);
                    Debug.Log(transform.position);
                    break;
                case "down":
                    vertical += movement;
                    transform.position = new Vector3(transform.position.x, (transform.position.y - movement), transform.position.z);
                    break;
                case "up":
                    vertical -= movement;
                    transform.position = new Vector3(transform.position.x, (transform.position.y + movement), transform.position.z);
                    break;
                default:
                    break;

            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
