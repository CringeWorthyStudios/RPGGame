using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateMachine : MonoBehaviour
{
    public enum State
    {
        crawl,
        walk,
        run,
    }
    public State state;

    public int stamina = 0;

    //These are replacing our Update() method
    private IEnumerator crawlState()
    {
        float startTime = Time.time;
        Debug.Log("Crawl: Enter");
        while (state == State.crawl)
        {
            yield return null;
        }

        Debug.Log("Crawling for " + (Time.time - startTime) + " Seconds");
        Debug.Log("crawl: Exit");
        NextState();
    }
    private IEnumerator walkState()
    {
        Debug.Log("Walk: Enter");
        while (state == State.walk)
        {
            yield return null;
        }
        Debug.Log("Walk: Exit");
        NextState();
    }
    private IEnumerator runState()
    {
        Debug.Log("Run: Enter");
        stamina = 0;
        while (state == State.run)
        {
            stamina++;
            Debug.Log("AHHHHHHHHHH!");
            yield return null;
        }
        Debug.Log("Run: Exit");
        NextState();
    }


    private void Start()
    {
        NextState();
    }
    //This will move us to our next state
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
    }

}