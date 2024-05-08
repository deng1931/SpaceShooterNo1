using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private float speed = .1f;
    void Start()
    {
        
        initialPosition = this.transform.position;
    }

    void Update()
    {
        //the new position = initial position + distance down(the distance down is the down speed multiply by time)
        //the mathf.repeat is a function used to loops the value t, so that it is never larger than length and never smaller than 0.
        //this line of code is used to work out the value of distance down 
        //to get the repeat effect, we let the value be repeated form 30 lengths, the value is distance down value,the 30 is the length of image
        float distanceDown = Mathf.Repeat(speed * Time.time, 30);
        transform.position = initialPosition + distanceDown * Vector3.back;
    }
}
