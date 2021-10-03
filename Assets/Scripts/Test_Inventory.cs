using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private int frame = 1;
    public Sprite spr;
    public float timeToLive;
    private float _timeLeft;
    void Start()
    {
        _timeLeft = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ( _timeLeft != 0f)
        {
            _timeLeft = Mathf.Clamp(_timeLeft - Time.deltaTime, 0, timeToLive);
        }
        else
        {
            GetComponent<Inventory>().DrawSlot(frame++, spr);
            frame = (frame % 4) + 1;
            _timeLeft = timeToLive;
        }
        
    }
}
