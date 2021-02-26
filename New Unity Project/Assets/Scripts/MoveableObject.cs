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
        displacement.z -= GameManager.instance.moveSpeed * Time.deltaTime;
        displacement.x -= Input.GetAxis("Horizontal") * GameManager.instance.moveSpeed * Time.deltaTime;
        transform.position += displacement;
    }
}
