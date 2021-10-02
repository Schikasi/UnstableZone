using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int max_health;
    private int _current_health;

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
    public bool get_damage(int damage_rate)
    {
        _current_health -= damage_rate;
        if (_current_health > 0) return true;
        else return false;
    }

    public void get_heal(int heal_rate)
    {
        _current_health += heal_rate;
        if (_current_health > max_health) _current_health = max_health;
    }
}
