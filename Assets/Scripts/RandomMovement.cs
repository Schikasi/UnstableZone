using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        CalculateAngle();
    }

    // Update is called once per frame
    public float CalculateAngle()
    {
        float dx = Random.value;
        if (Random.value > 0.5f)
            dx = -dx;
        float dy = Random.value;
        if (Random.value > 0.5f)
            dy = -dy;
        Vector2 movement = new Vector2(dx, dy);
        var angle = Vector2.SignedAngle(Vector2.up, movement);
        Debug.Log(angle);
        return angle;
    }


}
