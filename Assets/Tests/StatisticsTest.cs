using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StatisticsTest : MonoBehaviour
{
    [Test]
    public void TestAddSum()
    {
        GameObject testObject = new GameObject();
        StatisticsHandler statistics = testObject.AddComponent<StatisticsHandler>();
        Assert.AreEqual(10, statistics.AddSum(5, 5));
    }
}

