using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    [SerializeField] private float timeToHide;
    private float _currentTime;

    private Image _i;
    private Health _h;

    private void OnEnable()
    {
        _h ??= owner.GetComponent<Health>();
        _h.ChangeHealthEvent += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _h.ChangeHealthEvent -= UpdateHealthBar;
    }

    // Start is called before the first frame update
    void Start()
    {
        _i = GetComponent<Image>();
        Show();
    }

    private void UpdateHealthBar(float value)
    {
        var newAmount = value / _h.MaxHealth;
        _i.fillAmount = newAmount;
        Show();
    }

    private void Show()
    {
        var color = _i.color;
        color.a = 1.0f;
        _i.color = color;
        _currentTime = timeToHide;
    }

    private void Update()
    {
        if (_currentTime == 0.0f) return;
        Disappear();
    }

    private void Disappear()
    {
        _currentTime = Mathf.Clamp(_currentTime - Time.deltaTime, 0, timeToHide);
        var color = _i.color;
        color.a = _currentTime / timeToHide;
        _i.color = color;
    }
}