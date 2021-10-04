using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float cooldown = 0.8f;
    public float damage = 1f;
    public float Range = 1.0f;

    private CircleCollider2D myZone;
    private bool playerInRange = false;
    private float time_to_attack_left;
    private float e = 0.02f;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        myZone = gameObject.GetComponent<CircleCollider2D>();
        if (myZone == null) myZone = gameObject.AddComponent<CircleCollider2D>();
        myZone.radius = Range;
        anim = GetComponentInParent<Animator>();
        time_to_attack_left = 0f;
    }

    private void FixedUpdate()
    {
        time_to_attack_left = Mathf.Clamp(time_to_attack_left - Time.fixedDeltaTime, 0.0f, cooldown);
        Debug.DrawLine(transform.position, myZone.offset);
        if (!playerInRange) return;
        if (time_to_attack_left <= e)
        {
            anim.SetTrigger("Hit");
            var zmb = gameObject.GetComponentInParent<Zombie>();
            zmb.player.GetComponent<health>().get_damage(damage);
            time_to_attack_left = cooldown;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            playerInRange = false;
        }
    }

}
