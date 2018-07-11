using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRInterraction : MonoBehaviour
{
    public Camera cam; // камера
    public Image cursor; // прицел

    public float actionSpeed = 2; // скорость срабатывания действия
    float nextAction; // время до следующего действия

    public float multipleCursor = 3; // на сколько увеличить курсор
    RectTransform cursorTransform; // Компонент трансофрмации курсора
    Vector3 startCursorSize; // начальный размер курсора

    GameObject oldHitO; // прошлый объект столкновения


    void Start()
    {
        nextAction = actionSpeed; // начальное время до следующего действия
        cursorTransform = cursor.GetComponent<RectTransform>(); // получаем комонент трансофрмации курсора
        startCursorSize = cursorTransform.sizeDelta; // сохраняем стартовый размер курсора
    }


    void Update ()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // создаем луч из центра камеры
        RaycastHit hit; // объект который столкноется с лучем
        GameObject hitO; // текущий объект столкновения
        // Бросаем луч и проверяем столкновения
        if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<IInteractable>() != null) 
        {
            hitO = hit.transform.gameObject;  // записываем текущий объект столкновения
            // если текущий не равен прошлому то очищаем курсор и в прошлый записываем текущий
            if (hitO != oldHitO)  
            { 
                ClearCursor();
                oldHitO = hitO;
            }

            //Debug.Log(hit.transform.name);
            cursorTransform.sizeDelta += new Vector2(multipleCursor, multipleCursor) * Time.deltaTime; // меняем размер 
            if (Time.time > nextAction) // проверяем больше ли время игры времени до следующего действия
            {
                nextAction = Time.time + actionSpeed; // время до следующего действия теперь равно время игры плюс скорость срабатывания
                ClearCursor(); // очистка курсора
                hit.transform.GetComponent<IInteractable>().Act();
            }
        }
        else
        {
            ClearCursor(); // очистка курсора
            nextAction = Time.time + actionSpeed; // время до следующего действия теперь равно время игры плюс скорость срабатывания
        }


    }

    // возвращение курсора к начальному состоянию
    void ClearCursor()
    {
        cursorTransform.sizeDelta = startCursorSize;
    }

}
