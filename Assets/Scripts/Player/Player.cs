using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Для того чтобы задать силу")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D rb2d;
    [Space(15)]
    [Header("Проверка на прыжок")]
    private bool _isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask maskGround;
    [Header("Поиск Game Manager")]
    [SerializeField] private GameManager GM;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    {
        GroundChecker();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlyEnemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GM.health--;
        }
    }
    #region JumpSystem
    public void GroundChecker()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, maskGround);
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                rb2d.velocity = Vector2.up * _jumpForce;
            }
        }
    }
    #endregion
}
