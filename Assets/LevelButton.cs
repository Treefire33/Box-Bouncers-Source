using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [HideInInspector] public string levelNum;
    public TextMeshProUGUI buttonText;  
    public string levelNumStr; 
   


    // Start is called before the first frame update
    void Start()
    {
        levelNumStr = buttonText.text;
        switch(levelNumStr)
        {
            case "1":
            levelNum = "LevelOne";
            break;
            case "2":
            levelNum = "LevelTwo";
            break;
            case "3":
            levelNum = "LevelThree";
            break;
            case "4":
            levelNum = "LevelFour";
            break;
            case "5":
            levelNum = "LevelFive";
            break;
            case "6":
            levelNum = "LevelSix";
            break;
        }

    }

   public void LoadLevel()
    {
        SceneManager.LoadScene(levelNum, LoadSceneMode.Single);
    }
}