using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    
    public TypeAction tAction = TypeAction.None;
    public float cooldown = 0.9f;
    public float damage = 10f;

    private HashSet<GameObject> InActionZone;
    private float e = 0.1f;
    private float _curr_ttw = 0;
    // Start is called before the first frame update
    void Start()
    {
        InActionZone = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Action")) doAction();
    }

    private void doAction()
    {
        //Debug.Log("Action");
        if (_curr_ttw > e) _curr_ttw -= Time.fixedDeltaTime;
        if ( tAction == TypeAction.Atack )
        {
            if (Mathf.Abs(_curr_ttw) < e )
            {
                foreach ( var go in InActionZone )
                {
                    var health = go.gameObject.GetComponent<health>();
                    health?.get_damage(damage, health.TypeDamage.default_);
                }
                _curr_ttw = cooldown;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
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
