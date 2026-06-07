using System;
using UnityEngine;
using PrimeTween;
using Unity.VisualScripting;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Pattern patternOne;
    [SerializeField] private Pattern patternTwo;
    [SerializeField] private Pattern patternThree;
    [SerializeField] private float patternTimer = 5f;


    void Update()
    {
        if (levelManager.timeout)
        {
            patternTimer -= Time.deltaTime;
            if(patternTimer <= 0)
            {
                summonPatterns();
                patternTimer = 5f;
            }
            
        }
    }

    private void summonPatterns()
    {
        int num = UnityEngine.Random.Range(0, 2);
        switch (num)
        {
            case 0:
                Instantiate(patternOne,new Vector2(transform.position.x + UnityEngine.Random.Range(-1,1),transform.position.y),transform.rotation);
                break;
            case 1:
                Instantiate(patternTwo,new Vector2(transform.position.x + UnityEngine.Random.Range(-1,-8),transform.position.y),transform.rotation);
                break;
            case 2:
                Instantiate(patternThree,new Vector2(transform.position.x + UnityEngine.Random.Range(1,8),transform.position.y),transform.rotation);
                break;
            }      
    }
}
