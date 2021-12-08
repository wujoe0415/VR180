using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField]
    public Animator transition;

    [Range(0.0f,1.0f)]
    public float transitionTime = 1.0f;

    public int nextSceneIndex = 1;
    // Update is called once per frame
    public void TranstionScene()
    {
        Debug.Log("in");
        StartCoroutine("Transtion", nextSceneIndex);
    }

    IEnumerator Transtion(int nextSceneIndex)
    {
        // Animation
        transition.SetTrigger("Start");
        // WaitForSecond
        yield return new WaitForSeconds(transitionTime);
        // SwitchScene
        SceneManager.LoadScene(nextSceneIndex);

    }
}
