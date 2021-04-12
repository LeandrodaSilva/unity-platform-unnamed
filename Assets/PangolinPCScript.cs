using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangolinPCScript : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 5;
    private bool direita = true;
    public float jump = 500;
    private bool ground = true;
    private Animator animator;
    public LayerMask layerMask;
    public GameObject pe;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    transform.parent = collision.collider.transform;
    //    ground = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    transform.parent = null;
    //    ground = false;
    //}

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0)
        {
            animator.SetBool("movimento", false);
        }
        else
        {
            animator.SetBool("movimento", true);
        }

        rbd.velocity = new Vector2(x * vel, rbd.velocity.y);

        if (direita && x < 0 || !direita && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }

        //if(Input.GetKeyDown(KeyCode.Space) && ground)
        //{
        //    rbd.AddForce(new Vector2(0, jump));
        //}

        RaycastHit2D hit;

        hit = Physics2D.Raycast(pe.transform.position, -pe.transform.up, 0.5f, layerMask);

        if (hit.collider != null)
        {
            animator.SetBool("pulo", false);
            transform.parent = hit.collider.transform;
            Debug.Log(hit.collider.gameObject.layer);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbd.AddForce(new Vector2(0, jump));
            }
        }
        else
        {
            animator.SetBool("pulo", true);
            transform.parent = null;
        }
    }
}
