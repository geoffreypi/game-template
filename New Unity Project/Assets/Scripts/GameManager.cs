using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool boosting = false;
    public float maxSpeed { get; private set; } = 5f;
    public float maxAcc { get; private set; } = 0.05f;
    public float currentMoveSpeed { get; private set; } = 0f;
    [SerializeField] private Player player;

    
    private void Awake()
    {
        if(instance)
            Object.Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        EventManager.SpeedBoost += OnSpeedBoost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical")>0)
        {
            currentMoveSpeed += maxAcc;
        }
        else
        {
            currentMoveSpeed -= maxAcc;
        }

        currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, maxSpeed);
    }

    private void OnSpeedBoost()
    {
        if (!boosting)
        {
            StartCoroutine("SpeedBoost");
        }
    }

    private IEnumerator SpeedBoost()
    {
        maxSpeed *= 2f;
        maxAcc *= 2f;

        boosting = true;
        yield return new WaitForSeconds(5f);
        boosting = false;

        maxSpeed /= 2f;
        maxAcc /= 2f;
    }

}
