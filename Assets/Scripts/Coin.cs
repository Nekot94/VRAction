using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    public void Act()
    {
        GameController.instance.CollectCoins(); // вызываем сбор монет у гэеймконтроллера
        Destroy(gameObject); // уничтожаем монетку
    }
}
