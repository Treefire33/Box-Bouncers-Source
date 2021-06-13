using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    static int finishSave;
    public static bool op;
    public bool opop;
    public static void SaveData()
    {
        if(op)
        {
            finishSave = 1;
        }
        else if(!op)
        {
            finishSave = 0;
        }
        PlayerPrefs.SetInt("Finished", finishSave);
        PlayerPrefs.Save();
    }
    void Update()
    {
        opop = op;
    }
    void Awake()
    {
        if (PlayerPrefs.HasKey("Finished"))
	    {
		    finishSave = PlayerPrefs.GetInt("Finished");
            if(finishSave == 1)
            {
                op = true;
            }
            else if(finishSave == 0)
            {
                op = false;
            }
		    Debug.Log("Game data loaded!");
	    }
	    else
		    Debug.LogError("There is no save data!");
    }
}
