using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Awal());
    }
IEnumerator Awal()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<Collider>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
