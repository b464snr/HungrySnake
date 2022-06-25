using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profil : MonoBehaviour
{
    public Text Title;
    public Text Profile;
    public Text Input;
    private string Name;
    // Start is called before the first frame update
    public void profil()
    {
        Title.text = "PROFIL";
        Name = PlayerPrefs.GetString("Name","User");
        Display();
    }

    // Update is called once per frame
    void Display()
    {
        Profile.text =  Name + "\n" + PlayerPrefs.GetInt("HighScore",0).ToString();
    }
    public void ChangeName(){
        Name = Input.text;
        PlayerPrefs.SetString("Name",Name);
        Display();
    }
    
    public void ResetScore(){
        PlayerPrefs.DeleteKey("HighScore");
        Display();
    }
}
