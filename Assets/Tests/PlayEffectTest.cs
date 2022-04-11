using UnityEngine;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using System.Collections.Generic;

public class TestPlayTrack {

    public PlayEffect myPlayEffect;

    // Testas sėkmingas

    [Test]  // Testas MuteEffect() metodui.
    public void TestMuteEffect()  {

        GameObject name = new GameObject();
        myPlayEffect= name.AddComponent(typeof (PlayEffect)) as PlayEffect;

        myPlayEffect.MuteEffect();
        Assert.AreEqual(0.0f, myPlayEffect.effectVolume);

        myPlayEffect.MuteEffect();
        Assert.AreEqual(1.0f, myPlayEffect.effectVolume);
    }

    // Testas sėkmingas

     [Test] // Testas PlayMyEffect() metodui.
    public void TestPlayMyEffect() {
        
        // Sukuriamos nuorodos
        GameObject gameObject = new GameObject();
        AudioSource audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        PlayEffect myAcceptEffect = gameObject.AddComponent(typeof(PlayEffect)) as PlayEffect;
        
        // Priskiriamas efektas
        myAcceptEffect.effectSource = audioSource;  
        AudioClip myClip = Resources.Load<AudioClip>("Sounds/SFX_Accept");

        // Leidžiama ir tikrinama
        myAcceptEffect.PlayMyEffect(myClip);
        Assert.IsTrue(audioSource.isPlaying);
    }
}