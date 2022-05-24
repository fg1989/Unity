using System.Collections.Generic;
using UnityEngine;

public class ApparitionRocher : MonoBehaviour
{
    public GameObject rocher;

    private float delai;
    private float time;

    private List<float> spawns;

    public void Start()
    {
        spawns = new List<float>() { 3, 2.5f, 2.5f, 2, 2, 2, 1.5f, 1.5f, 1.5f, 1.5f, 1, 1, 1, 1, 1 };
    }

    public void Update()
    {
        if (Time.time > time + delai)
        {
            time = Time.time;
            if (spawns.Count > 0)
            {
                Instantiate(rocher);
                delai = spawns[0];
                spawns.RemoveAt(0);
            }
            else
            {
                delai = 0.1f;
                Instantiate(rocher).GetComponent<MouvementRocher>().final = true;
            }
        }
    }
}