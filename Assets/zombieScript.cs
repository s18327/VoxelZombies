using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine;

public class zombieScript : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 2;
    int MaxDist =15;
    int MinDist = 4;
    int FastMoveSpeed = 3;
    Animator anim;
    Rigidbody rb;



    void Start()
    {
         rb = GetComponent<Rigidbody>();
         anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        direction.y = 0;
        if(Vector3.Distance(transform.position, Player.position) >= MaxDist) { 
            direction.Equals(0);
            
            anim.SetFloat("Blend", 0f); 

        }

        else if (Vector3.Distance(transform.position, Player.position) <= MaxDist&& Vector3.Distance(transform.position, Player.position) > MinDist)
        {
            transform.LookAt(Player);

            anim.SetFloat("Blend",0.5f);
            // transform.position += direction * MoveSpeed * Time.smoothDeltaTime;
            rb.MovePosition((Vector3)transform.position + (direction * MoveSpeed * Time.smoothDeltaTime));
        }
        else if (Vector3.Distance(transform.position, Player.position) <= MinDist) {
            transform.LookAt(Player);
            //transform.position += direction * FastMoveSpeed * Time.smoothDeltaTime;
            anim.SetFloat("Blend",0.98f);
            rb.MovePosition((Vector3)transform.position + (direction * FastMoveSpeed * Time.smoothDeltaTime));
            
        }
    }



}
