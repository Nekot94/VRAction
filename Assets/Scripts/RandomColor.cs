using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour, IInteractable
{
    // Действие по перекрашиванию
    public void Act()
    {
       GetComponent<Renderer>().material.color = new Color(Random.value,
           Random.value, Random.value);
    }
}
