using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameController gc;
    [SerializeField] private PlayerMovement pm;

    private bool task1; //move
    private bool task2; //shoot portals
    private bool task3; //use portals
    private bool task4; //turret turn
    private bool task5; //companion cube

    private void Update()
    {
        if((Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")) && task1 == false)
        {
            task1 = true;
            Debug.Log("move it move it" + task1);
        }

        if((gc.blueWall != null && gc.orangeWall != null) && task2 == false)
        {
            task2 = true;
            Debug.Log("shoot it shoot it" + task2);
        }

        if((pm.isTeleported) && task3 == false)
        {
            task3 = true;
            Debug.Log("tererport" + task3);
        }
    }
}
