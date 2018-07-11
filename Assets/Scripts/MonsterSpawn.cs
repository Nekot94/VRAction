using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour {

    public float spawnTime = 3;
    public GameObject monster;

	void Start ()
    {
        StartCoroutine(Spawn());
	}
	
    IEnumerator Spawn()
    {
        while(true) // вечно повторять
        {
            yield return new WaitForSeconds(spawnTime);  // ждать время до спавна
            Instantiate(monster, transform.position, transform.rotation); // спавнить
        }
    }
}
