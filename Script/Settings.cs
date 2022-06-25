using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Text Title;
    public GameObject MusicOff;
    public GameObject MusicOn;
    public GameObject SFXOff;
    public GameObject SFXOn;
    public GameObject reset;
    private int Splay;
    private int SFXplay;
    // Start is called before the first frame update
    void Awake(){
        Title.text = "Pengaturan";
        Splay = PlayerPrefs.GetInt("Soundtrack",1);
        SFXplay = PlayerPrefs.GetInt("SFX",1);
        reset.gameObject.SetActive(false);
        if(Splay == 0){
            MusicOn.gameObject.SetActive(true);
            MusicOff.gameObject.SetActive(false);
        } else {
            MusicOn.gameObject.SetActive(false);
            MusicOff.gameObject.SetActive(true);

        }
        if(SFXplay == 0){
            SFXOn.gameObject.SetActive(true);
            SFXOff.gameObject.SetActive(false);
        } else {
            SFXOn.gameObject.SetActive(false);
            SFXOff.gameObject.SetActive(true);

        }
    }
    public void resetAll(){
        PlayerPrefs.DeleteAll();
    }
}
