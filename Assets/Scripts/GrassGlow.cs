using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassGlow : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    [Header("ChangeMaterial")]
    public Material InactiveMaterial;
    public Material GazedAtMaterial;

    private Renderer _myRenderer;

    [Header("SceneManager")]
    [SerializeField]
    public Animator transition;

    [Range(0.0f, 1.0f)]
    public float transitionTime = 1.0f;

    public int nextSceneIndex = 1;
    // Update is called once per frame
    public GameObject[] grassAnimals;
    public Material[] grassMaterials;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        InactiveMaterial = _myRenderer.material;
        SetMaterial(false);
        transition = GameObject.Find("GameCanvas").GetComponent<Animator>();
        grassAnimals = GameObject.FindGameObjectsWithTag("Grass");
    }

    /*private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnPointerEnter();
        }
    }*/
    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        // SeneSwitcher
        TranstionScene();
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            //_myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
            if(gazedAt)
            {
                foreach(GameObject grassAnimal in grassAnimals)
                {
                    grassAnimal.GetComponent<Renderer>().material = GazedAtMaterial;
                }
            }
            else
            {
                foreach (GameObject grassAnimal in grassAnimals)
                {
                    grassAnimal.GetComponent<Renderer>().material = InactiveMaterial;
                }
                
                /*foreach (GameObject grassAnimal in grassAnimals)
                {
                    for(int i = 0 ; i < grassMaterials.Length;i++)
                    grassAnimal.GetComponent<Renderer>().material = grassMaterials[i];
                }*/
            }
        }
    }

    // Scene Transition 
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
