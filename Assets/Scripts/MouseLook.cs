using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100; // чувствительность мыши
    public float clampAngle = 60; // максимальный угол на который смотрим вверх

    float rotY, rotX; // повороты по X и Y

    void Start ()
    {
        rotY = transform.localRotation.eulerAngles.y;  // Получаем начальное вращение по X
        rotX = transform.localRotation.eulerAngles.x;  // Получаем начальное вращение по Y
    }
	
	void Update ()
    {
        float mouseX = Input.GetAxis("Mouse X");  // Получаем положение мыши по X
        float mouseY = Input.GetAxis("Mouse Y"); // Получаем положение мыши по Y

        // меняем значение переменных поворота на движение мыши * на чувствительность
        rotX += mouseX * mouseSensitivity * Time.deltaTime; 
        rotY += mouseY * mouseSensitivity * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle); // отсекаем все что меньше -clampAngle и больше clampAngle

        // вращаем объект на нужные велечины
        transform.rotation = Quaternion.Euler(-rotY, rotX, 0);
    }
}
