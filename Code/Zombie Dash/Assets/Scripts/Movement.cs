using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public bool dash = true;
    public int dashCooldown = 80;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (dashCooldown == 0)
        {
            dash = true;
        } else
        {
            dashCooldown--;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.Space) && dash)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * 30);

            DashBar.instance.UseStamina(80);

            dash = false;
            dashCooldown = 80;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (SprintBar.currentStamina - 1 >= 0)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * 1.5f);

                SprintBar.instance.UseStamina(1);
            }

        }
    }
}
