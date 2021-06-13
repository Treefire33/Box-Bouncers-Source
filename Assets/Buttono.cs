using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttono : MonoBehaviour
{
    public Transform posS,posL;
    public GameObject[] menus;
    public bool nr, rn;
    public static bool Finished;
    // Start is called before the first frame update
    void Start()
    {
        Finished = Save.op;
    }

    // Update is called once per frame
    void Update()
    {
        Finished = Save.op;
        if(Input.GetKeyDown(KeyCode.P))
        {
            Finished = true;
        }
        if(Finished)
            if(nr)
            {
                Camera.main.gameObject.transform.position = Vector3.MoveTowards(Camera.main.gameObject.transform.position, posL.position, Time.deltaTime * 15f);
            }
            if(rn)
            {
                Camera.main.gameObject.transform.position = Vector3.MoveTowards(Camera.main.gameObject.transform.position, posS.position, Time.deltaTime * 15f);
            }
    }

    public void startl()
    {
        if(Finished)
        {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
        nr = true;
        rn = false;
        }
        else
        {
            SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
        }
    }
    public void starts()
    {
        menus[1].SetActive(false);
        menus[0].SetActive(true);
        rn = true;
        nr = false;
    }
    public void LevelEnter(string Level)
    {
        SceneManager.LoadScene(Level, LoadSceneMode.Single);
    }
    public void quitl()
    {
        Application.Quit();
    }
}
