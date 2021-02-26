using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float moveSpeed { get; private set; }
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
        
    }

    private void OnSpeedBoost()
    {
        StartCoroutine("SpeedBoost");
    }

    private IEnumerator SpeedBoost()
    {
        float elapsed = 0f;
        float duration = 5f;
        moveSpeed *= 2;
        while(elapsed < duration)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }
        moveSpeed /= 2;
    }

}
