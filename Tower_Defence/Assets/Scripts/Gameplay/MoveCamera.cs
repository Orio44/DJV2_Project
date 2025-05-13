using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private int speed;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10) transform.position = new(-10, transform.position.y);
        if (transform.position.x > 20) transform.position = new(20, transform.position.y);
        if (transform.position.y > 18) transform.position = new(transform.position.x, 18);
        if (transform.position.y < -20) transform.position = new(transform.position.x, -20);
        transform.position += Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right;
        transform.position += Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up;
    }
}
