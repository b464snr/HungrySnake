using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    public Text title;
    private string level;
    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        title.text = "Pilih Level";
    }
    public void level1(){
        PlayerPrefs.SetInt("level", 1);
        StartCoroutine(load());
    }

    public void level2(){
        PlayerPrefs.SetInt("level", 2);
        StartCoroutine(load());
        
    }

    public void level3(){
        PlayerPrefs.SetInt("level", 3);
        StartCoroutine(load());
    }

    public void level4(){
        PlayerPrefs.SetInt("level", 4);
        StartCoroutine(load());
    }

    IEnumerator load(){
        level = "level" +PlayerPrefs.GetInt("level", 0);
        loading.gameObject.SetActive(true);
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(level);
        while (!asyncload.isDone){
            yield return null;
        }
    }
}
