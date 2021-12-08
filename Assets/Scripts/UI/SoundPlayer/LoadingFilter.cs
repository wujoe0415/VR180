using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFilter : MonoBehaviour
{
    [SerializeField] Image filter;

    [Range(0.0f,1.0f)]
    public float progress = 0.0f;

    public float playingProgress = 0.0f;
    public float audioLength = 0.0f;
    public bool isPlay = false;
    private bool isPause = false;
    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            if(!isPause)
                playingProgress += Time.deltaTime;

            progress = Mathf.Clamp(playingProgress / audioLength, 0.0f, 1.0f);

            filter.fillAmount = progress;

            if (progress == 1.0f || playingProgress >= audioLength)
            {
                progress = 0.0f;
                EndPlaying();
            }
        }
    }

    public void StartPlaying(float Length)
    {
        playingProgress = 0.0f;
        isPlay = true;
        audioLength = Length;
    }

    public void PausePlaying()
    {
        isPause = true;
    }
    public void UnPausePlaying()
    {
        isPause = false;
    }

    public void EndPlaying()
    {
        playingProgress = 0.0f;
        isPlay = false;
        audioLength = 0;
        filter.fillAmount = 0.0f;
    }

}
