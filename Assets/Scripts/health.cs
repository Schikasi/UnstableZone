using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public float max_health;
    private float _current_health;

    public float Current_health { get => _current_health; }

    // Start is called before the first frame update
    void Start()
    {
        _current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // returns true if object is alive
    public bool get_damage(float damage_rate)
    {
        _current_health -= damage_rate;
        if (_current_health > 0f) return true;
        else return false;
    }

    public void get_heal(float heal_rate)
    {
        _current_health += heal_rate;
        if (_current_health > max_health) _current_health = max_health;
    }


}
