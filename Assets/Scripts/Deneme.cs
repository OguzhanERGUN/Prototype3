using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait2scnd());
        Debug.Log("Start çalýþtý");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Çalýþtý");
    }


    IEnumerator Wait2scnd()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine çalýþtý");
    }
}
