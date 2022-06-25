using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text Highscore;
    public Text CurrentStage;
    public GameObject GameUI;
    public Slider Objective;
    public int goal;
    private int TotalScore;
    private int beforeScore;
    private int Target;
    private bool count;
    public float transitionSpeed;
    public int kelipatanSkor;
    private float sc;
    // Start is called before the first frame update
    void Start()
    {
        Highscore.text = "Skor Tinggi : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        count = true;
        beforeScore = PlayerPrefs.GetInt("CurScore", 0);
        CurrentStage.text = "Level "  +PlayerPrefs.GetInt("level", 0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        
        sc =  Mathf.MoveTowards(sc, (float)player.score * (float)kelipatanSkor, transitionSpeed );
        TotalScore = beforeScore + (int)sc;
        ScoreText.text = TotalScore.ToString();
        if(count){
        if(Target < goal){
        Target = player.score;
        } else {
        Target = player.score - (goal * ((TotalScore / goal))-1);
        }
        }
        Objective.value = Target;
        Objective.maxValue = goal;
         if(Target == goal){
            GameUI.gameObject.GetComponent<GamePlay>().goal();
            count = false;
            PlayerPrefs.SetInt("CurScore", TotalScore);
        }
        if(TotalScore > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", TotalScore);
            Highscore.text = "Highscore : " + TotalScore.ToString();
        }
        
        }
    
    public void ResetHighscore(){
        PlayerPrefs.DeleteKey("HighScore");
        Highscore.text = "Highscore : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}

