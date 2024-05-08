using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int playerMoveSpeed = 8;
    private Rigidbody rigidbody;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float zMax;
    [SerializeField] private float zMin;
    //the vehicle's angle of rotate 
    private int tilt = -40;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rigidbody.useGravity = false;
        //the identity mean not have any rotation
        rigidbody.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        //transform.Translate(moveX * Time.deltaTime * playerMoveSpeed, 0, moveZ * Time.deltaTime * playerMoveSpeed);
        rigidbody.velocity = new Vector3(moveX * playerMoveSpeed, 0, moveZ * playerMoveSpeed);
        rigidbody.rotation = Quaternion.Euler(0, 0, tilt * moveX);

        //declare a v3 to let us can control the "this.transform.position" cuz the mathfr.clamp's parameter should be inputted a float value ,but the "this.transform.position" is v3 type 

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.z = Mathf.Clamp(newPosition.z, zMin, zMax);
        this.transform.position = newPosition;

        //you also can use the way like this :
        //float positionX = Mathf.Clamp(transform.position.x, xMin, xMax);
        //this .transform.position = new Vector3 (positionX, 0 , 0);


    }
}
