using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public delegate void DieHandle();

    public delegate void ChangeHealthHandle(float value);

    public event DieHandle DieEvent;
    public event ChangeHealthHandle ChangeHealthEvent;

    [SerializeField] private float maxHealth;
    [SerializeField] private TypeDamageResistance resists = new TypeDamageResistance(0f, 0f, 0f, 0f, 0f);

    private float _currentHealth;
    private bool _isAlive;

    public float MaxHealth => maxHealth;
        //public float CurrentHealth => _currentHealth;

    [System.Serializable]
    public struct TypeDamageResistance
    {
        [Range(0, 1)] public float default_;
        [Range(0, 1)] public float acid;
        [Range(0, 1)] public float toxin;
        [Range(0, 1)] public float gravity;
        [Range(0, 1)] public float nature;

        public TypeDamageResistance(float default_, float acid, float toxin, float gravity, float nature)
        {
            this.default_ = default_;
            this.acid = acid;
            this.toxin = toxin;
            this.gravity = gravity;
            this.nature = nature;
        }
    }

    public enum TypeDamage
    {
        Default = 0,
        Acid,
        Toxin,
        Gravity,
        Nature
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        _isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // returns true if object is alive
    public void get_damage(float value, TypeDamage type)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - value * (1 - GetResist(type)), 0f, maxHealth);
        ChangeHealthEvent?.Invoke(_currentHealth);
        if (_currentHealth > 0.0001f) return;
        _isAlive = false;
        DieEvent?.Invoke();
    }

    public void get_heal(float value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, maxHealth);
        ChangeHealthEvent?.Invoke(_currentHealth);
    }

    private float GetResist(TypeDamage typeDamage)
    {
        var returnValue = typeDamage switch
        {
            TypeDamage.Toxin => resists.toxin,
            TypeDamage.Default => resists.default_,
            TypeDamage.Acid => resists.acid,
            TypeDamage.Gravity => resists.gravity,
            TypeDamage.Nature => resists.nature,
            _ => 0f
        };
        return returnValue;
    }
}