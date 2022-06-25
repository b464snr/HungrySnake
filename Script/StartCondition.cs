using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCondition : MonoBehaviour
{
    public GameObject Box;
    public GameObject Loading;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Box.gameObject.activeSelf){
            if(Input.GetKeyDown(KeyCode.Space)){
                Time.timeScale = 1;
                Box.gameObject.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            PlayerPrefs.SetInt("Welc",1);
            Loading.gameObject.SetActive(true);
            SceneManager.LoadSceneAsync("MainMenu");
        }

    }

}
