using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public float max_health;
    public TypeDamageResistance resists = new TypeDamageResistance(0f, 0f, 0f, 0f, 0f);

    private float _current_health;

    public float Current_health { get => _current_health; }
    public struct TypeDamageResistance
    {
        public float default_;
        public float accid;
        public float toxin;
        public float gravity;
        public float nature;

        public TypeDamageResistance(float default_, float accid, float toxin, float gravity, float nature)
        {
            this.default_ = default_;
            this.accid = accid;
            this.toxin = toxin;
            this.gravity = gravity;
            this.nature = nature;
        }
    }

    public enum TypeDamage
    { 
        default_ = 0,
        accid,
        toxin,
        gravity,
        nature
    }

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
    public bool get_damage(float damage_rate, TypeDamage tdamage)
    {
        _current_health -= damage_rate * Mathf.Max(0, 1-GetResist(tdamage));
        if (_current_health > 0f) return true;
        else return false;
    }

    public void get_heal(float heal_rate)
    {
        _current_health += heal_rate;
        if (_current_health > max_health) _current_health = max_health;
    }

    private float GetResist(TypeDamage tdamage)
    {
        float return_value = 0f;
        if (tdamage == TypeDamage.toxin) return_value = resists.toxin;
        if (tdamage == TypeDamage.default_) return_value = resists.default_;
        if (tdamage == TypeDamage.accid) return_value = resists.accid;
        if (tdamage == TypeDamage.gravity) return_value = resists.gravity;
        if (tdamage == TypeDamage.nature) return_value = resists.nature;
        return return_value;
    }
}
