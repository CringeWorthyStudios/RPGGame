using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StatePointAI : MonoBehaviour
{
    #region class variables
    public float speed = 5f;
    public GameObject[] Waypoint;
    public float minDistance = 0.5f;
    public float chasePlayerDistance = 5f;
    public int index = 0;
    public GameObject player;
    public PlayerControllerAI playerController; // == null
    private float distance;
    private int direction = 0;
    #endregion
    public enum State//I added states for our ai
    {
        patrol,
        chase,
    }
    public State state;//I added states for our ai
    private void Start()
    {
        index = Random.Range(0, Waypoint.Length);
        minDistance = 1;

        playerController = player.GetComponent<PlayerControllerAI>();
        NextState();//I added this line in
    }
    //I DELETED UPDATE FROM WAYPOINTAI
    //CREATE THESE TWO METHODS
    private IEnumerator patrolState()
    {
        Debug.Log("patrol: Enter");
        while (state == State.patrol)
        {
            Patrol();
            yield return null;
            if(Vector3.Distance(player.transform.position, transform.position) < chasePlayerDistance)
            {
                state = State.chase;
            }
        }
        Debug.Log("patrol: Exit");
        NextState();
    }
    private IEnumerator chaseState()
    {
        Debug.Log("chase: Enter");
        while (state == State.chase)
        {
            MoveAI(player.transform.position);
            yield return null;

            if (Vector3.Distance(player.transform.position, transform.position) >= 0 && Vector3.Distance(player.transform.position, transform.position) <= (chasePlayerDistance * 0.3))
            {
                playerController.TakeHealthDamage(1);
            }

            if (Vector3.Distance(player.transform.position, transform.position) > chasePlayerDistance)
            {
                state = State.patrol;
            }
        }
        Debug.Log("chase: Exit");
        NextState();
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
    }//From WaypointAI
    void MoveAI(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }//from WaypointAI
    private void NextState()
    {
        //work out the name of the method we want to run
        string methodName = state.ToString() + "State"; //if our current state is "walk" then this returns "walkState"
        //give us a variable so we an run a method using its name
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        //Run our method
        StartCoroutine((IEnumerator)info.Invoke(this, null));
        //Using StartCoroutine() means we can leave and come back to the method that is running
        //All Coroutines must return IEnumerator
    }//from StateMachine
}