using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float normalSpeed = 2;

    public float superSpeed = 6;

    public float changeDistance = 1;

    public Vector3 startingPosition;
    public Vector3 endingPosition;

    private bool playerOnPlatform = false;
    private bool goingBackwards = false;

    void Start()
    {
        if(startingPosition == Vector3.zero)
        {
            startingPosition = this.transform.position;
        }
        playerOnPlatform = false;
        goingBackwards = false;
    }

    public void MovePlatform(float speed)
    {
        float remainingDist;
        if(goingBackwards)
        {
            remainingDist = Vector3.Distance(this.transform.position, startingPosition);
        }
        else
        {
            remainingDist = Vector3.Distance(this.transform.position, endingPosition);
        }

        if(remainingDist < changeDistance)
        {
            goingBackwards = !goingBackwards;
        }

        if(goingBackwards)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, startingPosition, speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, endingPosition, speed * Time.deltaTime);
        }
    }

    private void Update() 
    {
        if(!playerOnPlatform)
        {
            MovePlatform(normalSpeed);
        }    
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;
            transform.SetParent(this.transform);
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(playerOnPlatform == true)
        {
            MovePlatform(superSpeed);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;
            transform.SetParent(null);
        }
    }
}
