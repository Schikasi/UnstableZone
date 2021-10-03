using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    public GameObject Owner;
    public float timeToHide;
    private float curTime;

    private Image image;
    private health hc;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        hc = Owner.GetComponent<health>();
        curTime = timeToHide;
    }

    private void Update()
    {
        if (curTime != 0.0f)
        {
            curTime = Mathf.Clamp(curTime - Time.deltaTime, 0, timeToHide);
            var color = image.color;
            color.a = curTime / timeToHide;
            image.color = color;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (hc != null)
        {
            var newAmount = hc.Current_health / hc.max_health;
            if (newAmount != image.fillAmount)
            {
                image.fillAmount = newAmount;
                var color = image.color;
                color.a = 1.0f;
                image.color = color;
                curTime = timeToHide;
            }
        }
    }
}
