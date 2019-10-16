using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Animator anim;
    SpriteRenderer render;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
        } 
        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        }

        //anim
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("MoveX", true);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", false);
            render.flipX = true;
            anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("MoveX", true);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", false);
            render.flipX = false;
            anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetBool("MoveX", false);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", true);
            anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            anim.SetBool("MoveX", false);
            anim.SetBool("MoveUp", true);
            anim.SetBool("MoveDown", false);
            anim.speed = 1;
        }
        else { anim.speed = 0; }
    }
}
