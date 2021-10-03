using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawSlot(int idx, Sprite sprite)
    {
        if (idx == 1)
        {
            Image img = slot1.GetComponent<Image>();
            img.sprite = sprite;
        }
        else if (idx == 2)
        {
            Image img = slot2.GetComponent<Image>();
            img.sprite = sprite;
        }
        else if (idx == 3)
        {
            Image img = slot3.GetComponent<Image>();
            img.sprite = sprite;
        }
        else if (idx == 4)
        {
            Image img = slot4.GetComponent<Image>();
            img.sprite = sprite;
        }
        else Debug.Log("uce pogano! idx day normalno");
    }
}
