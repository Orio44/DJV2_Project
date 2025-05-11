using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = transform.Find("Sprite").GetComponent<Animator>();  
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Death();
        }
    }

    public void Death()
    {
        animator.SetTrigger("Death");
        StartCoroutine(DestroyAfterAnimation());
        
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }
}
