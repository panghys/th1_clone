using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int planksRequired;
    public GameManager gm;
    public List<Plank> planksSoFar;
    [SerializeField] private float levelTimer = 60f;
    public bool levelStart = false;
    public bool timeout = false;

    void Awake()
    {
        foreach(Transform plank in transform)
        {
            planksRequired++;
        }

        levelStart = true;
    }

    void Update()
    {

        if (levelStart)
        {
            levelTimer -= Time.deltaTime;
            if(levelTimer <= 0)
            {
                timeout = true;
                levelTimer = 10000f;
                levelStart = false;
            }
        }

        foreach(Transform plank in transform)
        {
            if (plank.GetComponent<Plank>().wasActivated && !planksSoFar.Contains(plank.GetComponent<Plank>()))
            {
                planksSoFar.Add(plank.GetComponent<Plank>());
                GameManager.instance.AddPoints(plank.GetComponent<Plank>().pointsWorth);
            }
        }

        if(planksSoFar.Count == planksRequired)
        {
            GameManager.instance.nextLevel();
        }
    }

    public void verificar()
    {
        Debug.Log(" de verdad estoy xd ");
    }
}
