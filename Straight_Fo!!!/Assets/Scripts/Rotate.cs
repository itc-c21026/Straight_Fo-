using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*---------------------------------
 î’ÇâÒì]Ç≥ÇπÇÈÉvÉçÉOÉâÉÄ
---------------------------------*/

public class Rotate : MonoBehaviour
{
    GameObject obj;
    RotateOnOffScript script;

    public float speed;

    //bool swich = true;

    private void Start()
    {
        obj = GameObject.Find("RotateSwitch");
        script = obj.GetComponent<RotateOnOffScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.Switch == true) { 
            transform.Rotate(new Vector3(0, 0.2f, 0)); 
        }else if (script.Switch == false)
        {
            transform.Rotate(new Vector3(0, -0.2f, 0));
        }
    }
}
