using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;

public class StatisticsTest2 : MonoBehaviour
{
    [Test]
    public void TestCompareTwoDataFiles()
    {
        GameObject testObject = new GameObject();
        StatisticsHandler statistics = testObject.AddComponent<StatisticsHandler>();
        //ar sito reikia kodo???
        string line = "";
        try
        {
            StreamReader sr = new StreamReader(@"C:\Users\LENOVO\Desktop\Darbalaukis\Universiteto\Trecias kursas\Pavasario Semestras\Programu kurimo procesas\Melagis-develop (1)\Melagis-develop\Assets\Statistics\testfile1.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
        Assert.AreEqual("testuojami duomenys", statistics.readtext());
    }
}