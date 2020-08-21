using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{

    public float speed = 10.0f;
    public GameObject[] Waypoint;
    public int index = 0;
    public float minDistance;
    public float chasePlayerDistance = 7f;


    public float distance;

    public GameObject player;
    public PlayerControllerAI playerController;


    int direction = 0;


    private void Start()
    {
        index = Random.Range(0, Waypoint.Length);
        minDistance = 1;
        //index = 0;

        playerController = player.GetComponent<PlayerControllerAI>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > chasePlayerDistance)
        {
            Patrol();
        }
        else
        {
            MoveAI(player.transform.position);
        }

        if (Vector3.Distance(player.transform.position, transform.position) >= 0 && Vector3.Distance(player.transform.position, transform.position) <= (chasePlayerDistance * 0.3))
        {
            playerController.TakeDamage(1);
        }

        //loop();

    }

    void loop()
    {

        distance = Vector3.Distance(transform.position, Waypoint[index].transform.position);


        if (index == 0)
        {
            direction = 1;
        }
        else if (index == (Waypoint.Length - 1))
        {
            direction = -1;
        }

        if (distance < minDistance && direction >= 0)
        {
            index++;
        }
        else if (distance < minDistance && direction < 0)
        {
            index--;
        }
        else
        {
            MoveAI(Waypoint[index].transform.position);
        }


    }

    void Patrol()
    {

        distance = Vector3.Distance(transform.position, Waypoint[index].transform.position);

        if (distance < minDistance)
        {
            index = Random.Range(0, Waypoint.Length);
        }
        else
        {
            MoveAI(Waypoint[index].transform.position);
        }

    }



    void MoveAI(Vector3 targetPosition)
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition , speed * Time.deltaTime );

    }

}
