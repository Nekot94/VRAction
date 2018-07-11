using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent; // компонент навигации
    GameObject target; // цель

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>(); // получаем компонент навигации
        target = GameObject.FindGameObjectWithTag("Player"); // получаем цель по тэгу
	}
	

	void Update ()
    {
        agent.SetDestination(target.transform.position); // Направить к цели
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.Lose(); // проигрываем при столкновение с игроком
        }
    }
}
