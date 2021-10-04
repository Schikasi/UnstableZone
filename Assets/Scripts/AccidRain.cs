using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidRain : MonoBehaviour
{
    public float Range = 4f;
    public float moveSpeed = 0.7f;
    public float timeToChangeDirection = 2f;
    public float damage = 5f;

    private RandomMovement rm;
    private float timeLeft = 0f;
    private float e = 0.2f;
    private float angle;
    private List<GameObject> GOinTrigger = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rm = gameObject.GetComponent<RandomMovement>();
        CircleCollider2D cc = gameObject.AddComponent<CircleCollider2D>();
        cc.radius = Range;
        cc.isTrigger = true;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {

        if (Mathf.Abs(timeLeft) < e)
        {
            timeLeft = timeToChangeDirection;
            angle = rm.CalculateAngle();
        }
        else timeLeft -= Time.fixedDeltaTime;
        Vector2 movement = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
        transform.Translate(movement * Time.fixedDeltaTime * moveSpeed);
        foreach(var go in GOinTrigger)
        {
            var health = go.gameObject.GetComponent<health>();
            health?.get_damage(damage * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Border>())
        {
            angle = -angle;
        }
        else if (!collision.isTrigger)
            GOinTrigger.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GOinTrigger.Remove(collision.gameObject);
    }
}
