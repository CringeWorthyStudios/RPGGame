using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSetting : MonoBehaviour
{

    public GameObject target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 15, target.transform.position.z);
        transform.eulerAngles = new Vector3(90, target.transform.eulerAngles.y, 0);
    }

}
