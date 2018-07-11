using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text coinText; // отображает коллчиество монет
    int coins; // колличество монет

    public Text endText; // сообщение в конце игры

    public static GameController instance; //хранит ссылку на объект

    private void Start()
    {
        instance = this; // записываем ссылку на данный объект
    }

    public void CollectCoins()
    {
        coins++; // колличество монет растет на 1
        coinText.text = coins.ToString(); // отображаем коллчиество монет
    }

    public void Lose()
    {
        endText.text = "Ты проиграл"; // меняем текст
        StartCoroutine(Restart()); // запускаем сопрограмму перезапуска
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2); // ждем
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // перезапускаем уровень
    }
    
}
