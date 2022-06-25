using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour
{
    RectTransform rectTransform;
    private Vector3 newPosition;
    private bool close = false;
    public Text welcomeText;
    private int welc;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        newPosition = new Vector3(rectTransform.anchoredPosition3D.x,400, 0);
        welcomeText.text = "Selamat Datang \n" + PlayerPrefs.GetString("Name","User");
    }

    // Update is called once per frame
    void Update()
    {
        if(welc == 0){
        StartCoroutine(WellCo());
        } else {
            Destroy(this.gameObject);
        }
    }

    IEnumerator WellCo(){
        yield return new WaitForSeconds(1);
        if(rectTransform.anchoredPosition3D == newPosition){
            close = true;
        } 
        if(close){
            yield return new WaitForSeconds(1);
            rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x,rectTransform.anchoredPosition3D.y + 10, 0);
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
            
        } else {
            rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x,rectTransform.anchoredPosition3D.y - 20, 0);
        }
    }
}
