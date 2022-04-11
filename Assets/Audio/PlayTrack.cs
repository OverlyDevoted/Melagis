using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// AudioHandler klasė išskaidyta į PlayTrack ir PlayEffect klases.
// PlayTrack klasė yra atsakinga už garso takelio leidimą, jo garso valdymą.

public class PlayTrack : MonoBehaviour
{

    // Papildomas kintamasis nenumatytas UML.

    [SerializeField] public AudioSource trackSource;

    [SerializeField] public List <AudioClip> trackList;

    // Unity metodas, naudojamas paleisti kitus metodus.

    public void Start() {

        PlayRandomTrack();
    }

    // Unity metodas, naudojamas atnaujinti kitus metodus.

    public void Update() {

        MuteTrackWithArrowKeys();
    }

    // Šis metodas atsitiktinai parenka ir paleidžia garso takelį.

    public void PlayRandomTrack() {

        int randomIndex = UnityEngine.Random.Range(0, trackList.Capacity);
        trackSource.clip = trackList[randomIndex];
        trackSource.Play();
    }

    // Šis metodas (susietas su mygtuku) įjungia/išjungia takelio garsą.

    public void MuteTrackWithButton() {

        if(!trackSource.isPlaying)
            trackSource.Play();
        else if(trackSource.isPlaying)
            trackSource.Pause();
    }

    // Šis metodas (susietas su klavišais) įjungia/išjungia takelio garsą.
    public void MuteTrackWithArrowKeys() {

        if(!trackSource.isPlaying && Input.GetKeyDown(KeyCode.UpArrow))
            trackSource.Play();
        else if(trackSource.isPlaying && Input.GetKeyDown(KeyCode.DownArrow))
            trackSource.Pause();
    }
}