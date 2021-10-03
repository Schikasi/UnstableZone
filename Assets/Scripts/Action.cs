using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private HashSet<GameObject> InActionZone;
    public TypeAction tAction = TypeAction.None;
    // Start is called before the first frame update
    void Start()
    {
        InActionZone = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Action"))doAction();
    }

    private void doAction()
    {
        Debug.Log("Action");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InActionZone.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InActionZone.Remove(collision.gameObject);
    }

    public enum TypeAction
    {
        None = 0,
        Atack = 1,
        detect = 2
    }
}
