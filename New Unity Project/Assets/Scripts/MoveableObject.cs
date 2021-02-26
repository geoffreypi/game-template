using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Vector3.zero;
        displacement.z -= GameManager.instance.currentMoveSpeed * Time.deltaTime;
        displacement.x -= Input.GetAxis("Horizontal") * GameManager.instance.currentMoveSpeed * Time.deltaTime;
        transform.position += displacement;
        if(transform.position.z < -5f)
        {
            Reset();
        }
    }

    public void Reset()
    {
        Vector3 displacement = transform.position;
        displacement.z = 42.5f;
        transform.position = displacement;
    }
}
