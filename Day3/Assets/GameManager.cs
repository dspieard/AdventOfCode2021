using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    
    string[] linesInFile = File.ReadAllLines(Application.streamingAssetsPath + "/" + "day3" + ".txt");
    char[] chararr;

    // Start is called before the first frame update
    void Start()
    {
        Task1();
        Task2();
    }

    private void Task1()
    {
        var totals = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (var line in linesInFile)
        {
            chararr  = line.ToCharArray();
            for (var i = 0; i < chararr.Length; i++)
            {
                totals[i] += int.Parse(chararr[i].ToString());
            }   

        }

        var gamma = "";
        var epsilon = "";
  

        foreach (int total in totals)
        {
            switch(total)
            {
                case var _ when total > 500:
                    gamma += "1";
                    epsilon += "0";
                    break;
                case var _ when total < 500:
                    gamma += "0";
                    epsilon += "1";
                    break;
                default:
                    break;
            }
        }

        Debug.Log(Convert.ToInt32(gamma,2) * Convert.ToInt32(epsilon,2));
    }

    private void Task2()
    {
        var oxygen = linesInFile.ToList();
        var co2 = linesInFile.ToList();

        for (var i = 0; i < 12; i++)
        {
            oxygen = MakeItWork(oxygen, i, true);
            co2 = MakeItWork(co2, i, false);
        }
        Debug.Log(oxygen.ToArray()[0]);
        Debug.Log(co2.ToArray()[0]);
        Debug.Log(Convert.ToInt32(oxygen.ToArray()[0], 2) * Convert.ToInt32(co2.ToArray()[0], 2));
    }

    private static List<string> MakeItWork(List<string> input, int i, bool isOxygen)
    {
        var zeroes = input.FindAll(x => x.ToCharArray()[i].Equals('0')).Count;
        var ones = input.FindAll(x => x.ToCharArray()[i].Equals('1')).Count;
        char remove;
        if (zeroes == 0 || ones == 0)
        { }
        else if (zeroes <= ones)
        {
            remove = isOxygen ? '0' : '1';
            input.RemoveAll(x => x.ToCharArray()[i].Equals(remove));
        }
        else
        {
            remove = isOxygen ? '1' : '0';
            input.RemoveAll(x => x.ToCharArray()[i].Equals(remove));
        }
        return input;
    }

}
