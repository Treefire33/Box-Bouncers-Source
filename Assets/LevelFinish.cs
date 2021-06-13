using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelFinish : MonoBehaviour
{
    public GameObject text;
    public GM gM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Marble")
            text.SetActive(true);
            StartCoroutine(switchScene());
    }
    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(2f);
        gM.Scene();
    }
}
