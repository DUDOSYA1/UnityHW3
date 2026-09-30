using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private CubeThrower[] dices;

    private int diceAmount;
    private int landedCounter;
    private bool shouldChange;
    private List<GameObject> currSides;

    private void Start()
    {
        diceAmount = dices.Length;
        landedCounter=0;
        shouldChange = false;
        currSides = new List<GameObject>();

        foreach (var dice in dices)
            dice.InProcess = false;
    }

    private void FixedUpdate()
    {
        if (landedCounter == diceAmount && shouldChange)
        {
            shouldChange = false;
            var sum = 0;
            Debug.Log(currSides);
            foreach (var obj in currSides)
            {
                switch (obj.name)
                {
                    case "1": sum += 6; break;
                    case "2": sum += 4; break;
                    case "3": sum += 5; break;
                    case "4": sum += 2; break;
                    case "5": sum += 3; break;
                    case "6": sum += 1; break;
                }
            }
            Debug.Log(sum);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        landedCounter++;
        currSides.Add(collision.gameObject);
        shouldChange = true;
        ChangeInProcessStatus();
        
    }

    private void OnCollisionExit(Collision collision)
    {
        landedCounter--;
        currSides.Remove(collision.gameObject);
        shouldChange = true;
        ChangeInProcessStatus();
    }

    private void ChangeInProcessStatus()
    {
        foreach (var dice in dices)
            dice.InProcess = !dice.InProcess;
    }

}
