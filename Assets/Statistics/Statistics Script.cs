using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Statisticsscript : MonoBehaviour
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
