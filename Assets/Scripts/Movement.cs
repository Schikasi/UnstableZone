using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��� ������� ����������� ��� ��� ������ �� ��������� ���� �� ������ ����� ������������� ��������� Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // �.�. ������ �������� ���������� �� ��������� ������� � ����� ����������� ��������
    public float Speed = 5f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // � ����� ������ ��������� ������������ ��� �����, �� ����� � � Update.
        // �� ��� �� �������� �����, �� 
        // ������� ����� ��������� ��������� fixedDeltaTim� 
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // ��� �� �������� ���� ���������� � ����� ������
        // � �������� ��� �� �������� �� FixedUpdate �� �������� �� fixedDeltaTim�
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
}
