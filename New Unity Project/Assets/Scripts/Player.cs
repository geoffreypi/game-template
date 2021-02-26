using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Invincible")
        {
            StartCoroutine("GoInvincible");
            other.gameObject.GetComponent<MoveableObject>().Reset();
        }
        else if(other.gameObject.tag == "Speedboost")
        {
            EventManager.OnSpeedBoost();
            other.gameObject.GetComponent<MoveableObject>().Reset();
        }
        else if (other.gameObject.tag == "Annoyance" && !invincible)
        {
            other.collider.enabled = false;
            // Do Something
        }
    }

    private IEnumerator GoInvincible()
    {
        invincible = true;
        yield return new WaitForSeconds(5f);
        invincible = false;
    }
}
