using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource thisaudio;
    public LoadingFilter loader;

    public bool isPlaying = false;
    public bool isPause = false;
    private void Update()
    {
        if (!loader.isPlay)
        {
            isPlaying = false;
            isPause = false;
        }
    }
    public void playSound()
    {
        if (!isPlaying && !isPause)
        {
            isPlaying = true;
            thisaudio = GetComponent<AudioSource>();
            StartCoroutine("PlayAudio");
            loader.StartPlaying(thisaudio.clip.length);
        }

        // Pause it
        else if (isPlaying)
        {
            Debug.Log("in");
            isPlaying = false;
            isPause = true;
            thisaudio.Pause();
            StopCoroutine("PlayAudio");
            loader.PausePlaying();
        }

        // UnPause it
        else if (isPause)
        {
            isPlaying = true;
            isPause = false;
            thisaudio.UnPause();
            loader.UnPausePlaying();
        }
    }
    IEnumerator PlayAudio()
    {
        //thisaudio = GetComponent<AudioSource>();
        thisaudio.Play();
        // animation
        yield return new WaitForSeconds(thisaudio.clip.length);
        thisaudio.Stop();
        // reset
    }
}
