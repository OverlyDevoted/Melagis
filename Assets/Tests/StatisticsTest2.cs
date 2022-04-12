using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;

public class StatisticsTest2 : MonoBehaviour
{
    // Testas, palygina 2 failus 
    [Test]
    public void TestCompareTwoDataFiles()
    {
        GameObject testObject = new GameObject();
        Statisticsscript statistics = testObject.AddComponent<Statisticsscript>();
        //Perskaitomas pirmas failas
        string line = "";
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(@"C:\Users\LENOVO\Desktop\Darbalaukis\Universiteto\Trecias kursas\Pavasario Semestras\Programu kurimo procesas\Melagis-develop (1)\Melagis-develop\Assets\Statistics\testfile1.txt");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
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

// BDD - Behaviour driven development buvo pritaikytas kuriant ðá testà
// TDD - Test Driven development buvo pritaikytas kuriant ðá koda -> parodyti test runnery su ivykdytais testais


// TDD Toks programinës technikos testavimo bûdas kurio metu testo atvejai yra kuriami,
// daþnai automatizuojami ir tada programinë árangà yra kartu kuriama inkrementaliai
// siekiant pereiti teiso scenarijus be klaidø. //Testo atvejai kuriami kartu su kodu.//