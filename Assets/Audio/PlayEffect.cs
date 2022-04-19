using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// AudioHandler klasė išskaidyta į PlayTrack ir PlayEffect klases.
// PlayEffect klasė yra atsakinga už garso efektų leidimą, jų garso valdymą.

public class PlayEffect : MonoBehaviour {

    [SerializeField] public AudioClip accept;
    [SerializeField] public AudioClip decline;
    [SerializeField] public AudioClip pickCard;
    [SerializeField] public AudioClip dropCard;
    [SerializeField] public AudioClip shuffleDeck;

    // Pridėti papildomi kintamieji nenumatyti UML.

    public float effectVolume {get; private set;} = 1.0f;
    [SerializeField] public AudioSource effectSource;
    
    // Šis metodas (susietas su mygtuku) leidžia įjungti/išjungti garso efektus.

    public void MuteEffect() {

        if (effectVolume > 0.0f)
            effectVolume = 0.0f;
        else
            effectVolume = 1.0f;
    }

    // Šis metodas (susietas su mygtuku) leidžia paleisti atitinkamus garso efektus.

    public void PlayMyEffect(AudioClip myEffect) {

        effectSource.PlayOneShot(myEffect, effectVolume);
    }
}