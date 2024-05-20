/*
 * Author: Wang Johnathan Zhiwen
 * Date: 19/05/2024
 * Description: 
 * The Door will Open after interacted with
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    bool locked = false;

    //When player enter in range for the specific door
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !opened || other.gameObject.tag == "Boulder" && !opened)
            other.gameObject.GetComponent<Player>().UpdateDoor(this);
    }

    //When player exit the range for the specific door
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Player>().UpdateDoor(null);
    }

    // What happens when door opens
    public void OpenDoor()
    {
        if (!locked)
        { 
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.y -= 90;
            transform.eulerAngles = currentRotation;
            opened = true;
        }
    }

    public void SetLock(bool lockStatus)
    {
        locked = lockStatus;
    }

}
