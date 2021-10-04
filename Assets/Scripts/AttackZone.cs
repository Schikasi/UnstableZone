using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float cooldown = 0.8f;
    public float damage = 1f;

    private Collider2D myZone;
    private bool playerInRange = false;
    private float time_to_attack_left;
    private float e = 0.02f;

    public Animation LeftHit;
    public Animation UpHit;
    public Animation RightHit;
    public Animation DownHit;


    // Start is called before the first frame update
    void Start()
    {
        myZone = gameObject.GetComponent<Collider2D>();
        time_to_attack_left = 0f;
    }

    private void FixedUpdate()
    {
        time_to_attack_left = Mathf.Clamp(time_to_attack_left - Time.fixedDeltaTime, 0.0f, cooldown);
        Debug.DrawLine(transform.position, myZone.offset);
        if (!playerInRange) return;
        if (time_to_attack_left <= e)
        {

            var zmb = gameObject.GetComponentInParent<Zombie>();
            zmb.player.GetComponent<health>().get_damage(damage);
            time_to_attack_left = cooldown;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.name == "Hero" )
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            playerInRange = false;
            time_to_attack_left = 0;
        }
    }

}
