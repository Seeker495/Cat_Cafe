using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;
    private Rigidbody2D m_rigidBody2D;
    private PlayerController m_controller;

    [SerializeField] private float m_speed;

    private void Awake()
    {
        TryGetComponent(out m_spriteRenderer);
        TryGetComponent(out m_rigidBody2D);
        m_controller = new PlayerController();
        m_controller.Play.Move.started += Move;
        m_controller.Play.Move.performed += Move;
        m_controller.Play.Move.canceled += StopMoving;
        m_controller.Play.Enable();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();
        if (move.x <= -1) m_spriteRenderer.flipX = false;
        else if (move.x >= 1) m_spriteRenderer.flipX = true;
        else m_spriteRenderer.flipX = m_spriteRenderer.flipX;
        m_rigidBody2D.velocity = move * m_speed;
    }

    public void StopMoving(InputAction.CallbackContext context)
    {
        m_rigidBody2D.velocity = Vector2.zero;
    }
}
