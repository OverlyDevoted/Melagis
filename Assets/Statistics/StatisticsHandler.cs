using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StatisticsHandler : MonoBehaviour
{
    public int AddSum(int x, int y)
    {
        return x + y;
    }

    public string readtext()
    {
        string line = "";
        try
        {
            //padaryk taip kad failu skaitymas ir rasymas veiktu bet kokio programuoto, vartotojo sistemoje
            //uzvedimas ant kelio https://docs.unity3d.com/ScriptReference/Resources.Load.html
            StreamReader sr = new StreamReader(@"C:\Users\LENOVO\Desktop\Darbalaukis\Universiteto\Trecias kursas\Pavasario Semestras\Programu kurimo procesas\Melagis-develop (1)\Melagis-develop\Assets\Statistics\testfile2.txt");
            line = sr.ReadLine();
            while (line != null)
            {
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
        return line;
    }
}
