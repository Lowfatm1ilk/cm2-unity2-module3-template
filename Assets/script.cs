using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class script : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Zombie"))
        {
            health--;
        }
    }
}
