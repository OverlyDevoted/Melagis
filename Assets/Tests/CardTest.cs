using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestToString()
    {
        GameObject cardModel = new GameObject("PlayingCards_2Club");
        Card card = new Card(cardModel);

        Assert.AreEqual("Club 2", card.ToString());
        // Use the Assert class to test conditions
    }
}
