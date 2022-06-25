using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Box;
    public Button ProBut;
    public Button SettBut;
    [HideInInspector]
    public GameObject BoxAtribute;
    public GameObject Music;
    private int Splay;
    private int SFXplay;

    void Awake(){
        PlayerPrefs.SetInt("CurScore", 0);
        Splay = PlayerPrefs.GetInt("Soundtrack",1);
        SFXplay = PlayerPrefs.GetInt("SFX",1);
        if(Splay == 0){
            Music.gameObject.SetActive(false);
        }
    }

    public void OpenBox(){

        if(Box.gameObject.activeSelf){
            CloseBox();
        } else {
            Box.gameObject.SetActive(true);
            ProBut.interactable = false;
            SettBut.interactable = false;
        }
    }
    
    public void CloseBox(){
        ProBut.interactable = true;
        SettBut.interactable = true;
        BoxAtribute = GameObject.FindGameObjectWithTag("BoxAtribute");
        BoxAtribute.gameObject.SetActive(false);
        Box.gameObject.SetActive(false);
    }

    public void ExitButton(){
        if(Box.gameObject.activeSelf){

        } else {
        Application.Quit();
        Debug.Log("closed");
        }
    }
    public void Soundtrack(){
        if(Splay == 0){
        PlayerPrefs.SetInt("Soundtrack",1);
        Splay = 1;
        } else {
            PlayerPrefs.SetInt("Soundtrack",0);
            Splay = 0;
        }
    }

    public void SFX(){
        if(SFXplay == 0){
        PlayerPrefs.SetInt("SFX",1);
        Splay = 1;
        } else {
            PlayerPrefs.SetInt("SFX",0);
            SFXplay = 0;
        }
    }
}
