using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Animator animator;
    bool bShouldShoot;
    bool facingleft;
    float xinput, zinput;
    float speed = 3.0f;
    bool iswalking;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        bShouldShoot = false;
        facingleft = false;
        iswalking = false;
	}
	
	// Update is called once per frame
	void Update () {
        xinput = Input.GetAxisRaw("Horizontal");
        zinput = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButton(0))
            bShouldShoot = true;
	}

    private void LateUpdate()
    {
        iswalking = (xinput == 0 && zinput == 0) ? false : true;
        animator.SetBool("iswalking", iswalking);
        animator.SetFloat("x", xinput);
        animator.SetFloat("z", zinput);
        if (xinput < 0 && !facingleft)
            Mirror();
        else if (xinput > 0 && facingleft)
            Mirror();
        transform.position += new Vector3(xinput, 0, zinput) * speed * Time.deltaTime; 
        if (bShouldShoot)
        animator.SetTrigger("shoot");
    }

    void Mirror()
    {
        facingleft = !facingleft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
