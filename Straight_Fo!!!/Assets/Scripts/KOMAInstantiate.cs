using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------
 メニュー画面(タイトル画面)で駒を召喚させる
-----------------------------------------*/

public class KOMAInstantiate : MonoBehaviour
{
    public GameObject obj;

    private void Start()
    {
        obj = (GameObject)Resources.Load("KOMA_blue");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= 540 && Input.mousePosition.x <= 740 && Input.mousePosition.y >= 300 && Input.mousePosition.y <= 500)
        {
            Instantiate(obj, new Vector3(Random.Range(-19, -5), 1, Random.Range(-10, 10)), Quaternion.identity);           
        }
    }
}
