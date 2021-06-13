using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Box : MonoBehaviour, IPointerClickHandler
{
    public GM gm;
    public GameObject high, doorhigh;
    public bool Selected;
    public AudioSource soundeffect;
    public AudioClip Select;
    public GameObject high1;
    public bool qwop,askl;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        qwop = gm.Box1Filled;
        askl = gm.Box2Filled;
        if(Input.GetKeyDown(KeyCode.Return) && qwop && askl)
        {
            UnHigh(high1);
        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(!Selected)
        {
            if(!gm.Box1Filled)
            {
                gm.Box1Filled = true;
                var fre = GameObject.Find(name);
                if(name.Contains("Door"))
                {
                    gm.Door = true;
                    high1 = HighlightDoor(fre);
                }
                else
                {
                    high1 = Highlight(fre);
                }
                gm.boxes[0] = fre;
                soundeffect.clip = Select;
                soundeffect.Play();
            }
            else if(!gm.Box2Filled)
            {
                gm.Box2Filled = true;
                var fre = GameObject.Find(name);
                if(name.Contains("Door"))
                {
                    gm.Door = true;
                    high1 = HighlightDoor(fre);
                }
                else
                {
                    high1 = Highlight(fre);
                }
                gm.boxes[1] = fre;
                soundeffect.clip = Select;
                soundeffect.Play();
            }
            Selected = true;
        }
    }
    GameObject Highlight(GameObject op)
    {
        var iop = Instantiate(high);
        iop.GetComponent<SpriteRenderer>().sortingOrder = -1;
        iop.transform.position = op.transform.position;
        iop.transform.rotation = op.transform.rotation;
        return iop;
    }
    GameObject HighlightDoor(GameObject op)
    {
        var iop = Instantiate(doorhigh);
        iop.GetComponent<SpriteRenderer>().sortingOrder = -1;
        iop.transform.position = op.transform.position;
        iop.transform.rotation = op.transform.rotation;
        iop.transform.localScale = new Vector3(op.transform.localScale.x + 0.1f, op.transform.localScale.y + 0.1f, op.transform.localScale.z + 0.1f);
        return iop;
    }
    void UnHigh(GameObject op)
    {
        GameObject.Destroy(op);
    }
}
