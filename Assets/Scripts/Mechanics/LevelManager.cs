using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int planksRequired;
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
            }
        }

        if(planksSoFar.Count == planksRequired)
        {
            Debug.Log("yattaa");
        }
    }
}
