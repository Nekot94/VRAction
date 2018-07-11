using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IInteractable
{
    // уничтожить объект
    public void Act()
    {
        Destroy(gameObject);
    }
}
