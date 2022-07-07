using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCTRL : MonoBehaviour
{
    [SerializeField] float walk;
    Animator animator;
    bool fWalk;
    bool bWalk;
    bool jump;


    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        fWalk = false;
        bWalk = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walk = Input.GetAxis("Vertical");
        if (walk > 0 && fWalk == false)
        {
            animator.SetBool("isWalking", true);
            fWalk = true;
        }

        if (walk == 0)
        {
            if (fWalk == true)
            {
                animator.SetBool("isWalking", false);
                fWalk = false;
            }
            if (bWalk == true)
            {
                animator.SetBool("isWalkingBack", false);
                bWalk = false;
            }
        }

        if (walk! < 0 && bWalk == false)
        {
            animator.SetBool("isWalkingBack", true);
            bWalk = true;
        }
        if (Input.GetButtonDown("Jump") && jump == false)
        {
            animator.SetBool("isJumping", true);
            jump = true;
        }
        if (!Input.GetButtonDown("Jump") && jump == true)
        {
            animator.SetBool("isJumping", false);
            jump = false;
        }

    }
}
