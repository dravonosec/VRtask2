using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    public bool zombieState = true;
    public float speed = 2f;
    public float accuracy = 0.01f;
    public Transform goal;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.LookAt(goal.position);
        Vector3 direction = new Vector3 (goal.position.x- this.transform.position.x,0, goal.position.z - this.transform.position.z);
        if(Input.GetKey(KeyCode.Tab))
        {
            zombieState = !zombieState;
        }
        if (direction.magnitude > accuracy & zombieState == false)
        {
            anim.SetBool("run", true);
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            anim.SetBool("run", false);
        }
        
    }
}
