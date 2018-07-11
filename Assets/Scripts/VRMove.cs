using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMove : MonoBehaviour
{
    public float speed = 10; // скорость
    public Camera cam; // камера игрока
    public float toggleAngle = 30; // угол на который нам надо наклонится чтобы идти

    bool canMove; // может ли игрок двигаться

    Rigidbody body; // физический компонент

    void Start ()
    {
        body = GetComponent<Rigidbody>();
	}

    //void Update ()
    //   {
    //       Vector3 forward = cam.transform.forward;
    //       transform.position += forward * speed * Time.deltaTime;
    //}

    void FixedUpdate()
    {
        //if (cam.transform.eulerAngles.x >= toggleAngle && cam.transform.eulerAngles.x <= 90)
        //{
        //    canMove = true;
        //}
        //else
        //{
        //    canMove = false;
        //}

        canMove = cam.transform.eulerAngles.x >= toggleAngle && cam.transform.eulerAngles.x <= 90; // меняет canMove в зависмости от угла наклона камеры

        // если можно двигаться то перемещать объект
        if (canMove)
        {
            Vector3 forward = cam.transform.forward; //  получаю перед у камеры
            body.velocity = forward * speed; // меняем скорость у rigidbody
        }
    }
}
