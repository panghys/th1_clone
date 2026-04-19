using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int planksRequired;
    public GameManager gm;
    public List<Plank> planksSoFar;

    void Awake()
    {
        foreach(Transform plank in transform)
        {
            planksRequired++;
        }
    }

    void Update()
    {
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
