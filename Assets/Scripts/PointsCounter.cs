using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private Rigidbody[] dices;

    private Dictionary<Collision,Rigidbody> sides;
    private Dictionary<Rigidbody, bool> areDicesLanded;
    private bool[] isLanded;


    private void Start()
    {
        if (dices == null)
            Debug.LogError("No dices");

        isLanded = new bool[dices.Length];
        for (int i = 0; i < dices.Length; i++)
        {
            isLanded[i] = true;
            areDicesLanded[dices[i]] = false;
            for(int j = 0; j < 6; j ++)
                sides[dices[i].transform.GetChild(j).GetComponent<Collision>()] = dices[i];
        }
    }

    private void Update()
    {
        foreach (var landed in areDicesLanded.Values)
        {
            if (!landed)
                return;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        areDicesLanded[sides[collision]] = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        areDicesLanded[sides[collision]] = false;
    }

}
