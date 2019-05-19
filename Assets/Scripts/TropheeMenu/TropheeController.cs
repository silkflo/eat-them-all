using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TropheeController : MonoBehaviour
{

    [SerializeField]
    private GameObject  backButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SuccessMenu()
    {
        SceneManager.LoadScene(TagManager.SUCCESS_SCENE);
    }


}
