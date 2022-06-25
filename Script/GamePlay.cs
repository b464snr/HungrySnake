using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject StartBox;
    public GameObject GoalBox;
    public GameObject LoseBox;
    public GameObject Pause;
    public GameObject Box;
    public GameObject Music;
    public GameObject Loading;
    public AudioSource GoalSFX;
    private string level;
    private int Splay;
    private int SFXplay;
    private bool cantResume;

    void Start(){

        Time.timeScale = 0;
        cantResume = false;
        level = "level" +(PlayerPrefs.GetInt("level",0)+1);

        Splay = PlayerPrefs.GetInt("Soundtrack",1);
        SFXplay = PlayerPrefs.GetInt("SFX",1);
        if(Splay == 0){
            Music.gameObject.SetActive(false);
        }
        if(SFXplay == 0){
            GoalSFX.mute = true;
        }
    }
    void Update()
    {

        if(LoseBox.gameObject.activeSelf){
            Box.gameObject.SetActive(true);
            cantResume = true;
            Time.timeScale = 0;
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(Time.timeScale == 0){
            resume();
            Pause.gameObject.SetActive(false);       
            } else {
                pause();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            mainMenu();
        }
    }
    public void mainMenu(){
        Time.timeScale = 0;
        cantResume = true;
        PlayerPrefs.SetInt("CurScore", 0);
        Loading.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void resume()
    {
        
        if(StartBox.gameObject.activeSelf)
        {      
            StartBox.gameObject.SetActive(false);      
        }
        if(!cantResume){
            Time.timeScale = 1;
        }
        
    }

    public void pause()
    {
        Time.timeScale = 0;
        Pause.gameObject.SetActive(true);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("CurScore", 0);
        Loading.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void goal(){
        Time.timeScale = 0;
        Music.gameObject.SetActive(false);
        Box.gameObject.SetActive(true);
        GoalBox.gameObject.SetActive(true);
        cantResume = true;
        
    }
    public void nextLevel(){
        Loading.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(level);
    }
    public void looplevel(){
        Loading.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync("level1");
    }
}
