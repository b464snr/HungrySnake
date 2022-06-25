using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float Kecepatan;
    public float SensivitasGerak;
    public GameObject Badan;
    public GameObject Food;
    public int JarakAntarTubuh;
    public Vector3 startPosition;
    //border
    public GameObject Border;
    private float Borderx;
    private float Borderz;
    //score
    [HideInInspector]
    public int score;
    // kalah
    public GameObject lose;
    // suaraMakan
    public AudioSource SFXmakan;
    [HideInInspector]
    public float BodySpeed = 5;
    [HideInInspector]
    public Vector3 row;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private int SFXplay;
    public GameObject Soundtrack;
    // Start is called before the first frame update
    void Start()
    {
        Borderx = ((float)Border.transform.localScale.x / 2)-1;
        Borderz = ((float)Border.transform.localScale.z / 2)-1;
        transform.position = startPosition;
        Pertumbuhan();
        Pertumbuhan();
        Pertumbuhan();

        SFXplay = PlayerPrefs.GetInt("SFX",1);
        if(SFXplay == 0){
            SFXmakan.mute = true;
        }

        Instantiate (Food, new Vector3(Random.Range(-Borderx,Borderx),-3,Random.Range(-Borderz,Borderz)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Kecepatan * Time.deltaTime;
        float headDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * headDirection * SensivitasGerak * Time.deltaTime);
        PositionsHistory.Insert(0,transform.position);
        int index =0;
        if(index == 0){
            row = gameObject.transform.position;
        }
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Min(index * JarakAntarTubuh, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            row = point;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }
    private void Pertumbuhan(){
        GameObject body = Instantiate(Badan,row,Quaternion.identity);
        BodyParts.Add(body);
    }
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Food"){
            Destroy(other.gameObject);
            SFXmakan.Play();
            score = score + 1;
            Pertumbuhan();
            Pertumbuhan();
            Instantiate (Food, new Vector3(Random.Range(-Borderx,Borderx),-3,Random.Range(-Borderz,Borderz)), Quaternion.identity);
        }
        if (other.tag == "Obstacle"){
            lose.SetActive(true);
            Soundtrack.gameObject.SetActive(false);
        }
    }
}
