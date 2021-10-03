using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this row ensures that the script won't crush in case of absence of component Rigidbode
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // �.�. ������ �������� ���������� �� ��������� ������� � ����� ����������� ��������
    public float Speed = 5f;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _rb.freezeRotation = true;
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
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.y);
        _sr.sortingOrder = -(int)(transform.position.y*100);
    }
}
