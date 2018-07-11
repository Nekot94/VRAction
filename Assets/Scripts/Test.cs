using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Kill();
        Kill(5);
        int i = 5;

        Kill2(ref i);
    }

    // Update is called once per frame
    void Update () {
		
	}

    //Перегрузка
    void Kill()
    {
        Debug.Log("Kill");
    }

    void Kill(int i)
    {
        Debug.Log("Kill" + i);
    }

    void Kill(out int i)
    {
        i = 10;
        Debug.Log("Kill" + i);
    }

    void Kill2(ref int i)
    {
        Debug.Log("Kill" + i);
    }
}
