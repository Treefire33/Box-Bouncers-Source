using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GM : MonoBehaviour
{
    public GameObject[] boxes;
    public GameObject marble;

    bool isPlaying;

    public bool Box1Filled,Box2Filled, Door;
    public AudioSource audioSource, soundeffect;
    public AudioClip audC,Audc;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audC;
        audioSource.loop = true;
        audioSource.Play();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(Box1Filled&&Box2Filled)
            {
                audioSource.clip = Audc;
                if(!Door)
                {
                    joinBoxSpring();
                }
                else
                {
                    joinBoxHinge();
                }
                DeleteConn();
                if(!isPlaying)
                {
                    audioSource.Play();
                    isPlaying = true;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene("TestTestTest", LoadSceneMode.Single);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("LevelSix", LoadSceneMode.Single);
        }
    }

    void joinBoxSpring()
    {
        boxes[0].AddComponent<SpringJoint2D>();
        boxes[0].GetComponent<SpringJoint2D>().connectedBody = boxes[1].GetComponent<Rigidbody2D>();
        boxes[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxes[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        marble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        marble.GetComponent<Rigidbody2D>().mass = 0.5f;
    }
    void joinBoxHinge()
    {
        boxes[0].AddComponent<HingeJoint2D>();
        boxes[0].GetComponent<HingeJoint2D>().connectedBody = boxes[1].GetComponent<Rigidbody2D>();
        boxes[1].GetComponent<Rigidbody2D>().mass = 0.4f;
        boxes[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxes[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        marble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        marble.GetComponent<Rigidbody2D>().mass = 0.5f;
    }
    public void DeleteConn()
    {
        boxes[0] = null;
        boxes[1] = null;
        Box1Filled = false;
        Box2Filled = false;
    }
    public void Scene()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "LevelOne":
                Save.SaveData();
                //buttonLevel.buttons[1].SetActive(true);
                SceneManager.LoadScene("LevelTwo");
            break;
            case "LevelTwo":
                Save.SaveData();
                //buttonLevel.buttons[2].SetActive(true);
                SceneManager.LoadScene("LevelThree");
            break;
            case "LevelThree":
                Save.SaveData();   
                //buttonLevel.buttons[3].SetActive(true);
                SceneManager.LoadScene("LevelFour");
            break;
            case "LevelFour":
                Save.SaveData();
                SceneManager.LoadScene("LevelFive");
            break;
            case "LevelFive":
                Save.SaveData();
                SceneManager.LoadScene("LevelSix");
            break;
            case "LevelSix":
                Buttono.Finished = true;
                Save.op = true;
                Save.SaveData();
                SceneManager.LoadScene("Title");
            break;
        }
    }
    void RestartLevel()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "LevelOne":
                SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
            break;
            case "LevelTwo":
                SceneManager.LoadScene("LevelTwo", LoadSceneMode.Single);
            break;
            case "LevelThree":
                SceneManager.LoadScene("LevelThree", LoadSceneMode.Single);
            break;
            case "LevelFour":
                SceneManager.LoadScene("LevelFour", LoadSceneMode.Single);
            break;
            case "LevelFive":
                SceneManager.LoadScene("LevelFive", LoadSceneMode.Single);
            break;
            case "LevelSix":
                SceneManager.LoadScene("LevelSix", LoadSceneMode.Single);
            break;
        }
    }
    
}
