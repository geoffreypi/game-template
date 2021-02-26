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
        }
        else if(other.gameObject.tag == "Speedboost")
        {
            EventManager.OnSpeedBoost();
        }
        else if (other.gameObject.tag == "Annoyance" && !invincible)
        {
            // Do Something
            other.collider.enabled = false;
        }
    }

    private IEnumerator GoInvincible()
    {
        float elapsed = 0f;
        invincible = true;
        while(elapsed < 5f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }
        invincible = false;
    }
}
