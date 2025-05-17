using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneScript : MonoBehaviour
{ 
    public float stayTimer = 5f;
    public float startingZoneSize = 50;
    public float zoneRadiusDivider = 1.5f;
    public Vector3 zoneLocationRange;
    public GameObject insideZoneTextHelper;

    bool playerInside = false;
    float timer = 0;

    [SerializeField]
    private GameObject zoneObject;

    public UnityEvent ZoneSuccessful;

    void Start()
    {
        if(zoneObject == null)
        {
            zoneObject = this.gameObject;
        }
        RandomizeZoneLocation();
        zoneObject.transform.localScale = Vector3.one * startingZoneSize;
        SetZoneHelper(false);
        playerInside = false;
        timer = stayTimer;
    }

    public void RandomizeZoneLocation()
    {
        float location_X = Random.Range(-zoneLocationRange.x,zoneLocationRange.x);
        float location_Y = Random.Range(0,zoneLocationRange.y);
        float location_Z = Random.Range(-zoneLocationRange.z,zoneLocationRange.z);

        zoneObject.transform.position = new Vector3(location_X, location_Y, location_Z);
    }

    public void ZoneSuccess()
    {
        RandomizeZoneLocation();
        zoneObject.transform.localScale = zoneObject.transform.localScale/zoneRadiusDivider;
        ZoneSuccessful?.Invoke();
        playerInside = false;
        timer = stayTimer;
    }

    public void SetZoneHelper(bool show)
    {
        insideZoneTextHelper?.SetActive(show);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            SetZoneHelper(true);
            timer = stayTimer;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (playerInside == true)
        {
            timer =- Time.deltaTime; 
            if (timer == 0)
            {
                ZoneSuccess();
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        playerInside = false;
        SetZoneHelper(false);
        timer = stayTimer;
    }
}
