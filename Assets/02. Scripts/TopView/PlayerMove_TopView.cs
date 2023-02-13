using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_TopView : MonoBehaviour
{
    Animator _animator;

    private float moveSpeed = 10.0f;

    private static readonly int IsMove = Animator.StringToHash("IsMove");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }
    
    void Move()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 moveVec = new Vector2(X, Y);
        if (moveVec != Vector2.zero)
        {
            transform.Translate(Time.deltaTime * moveSpeed * moveVec);
            _animator.SetBool(IsMove, true);

            if (X == -1) transform.localScale = new Vector3(-1, 1, 1);
            else if (X == 1) transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _animator.SetBool(IsMove, false);
        }
        
    }
}
