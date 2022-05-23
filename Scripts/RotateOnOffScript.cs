using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------
 回転のオンオフを切り替えるプログラム
------------------------------------------*/

public class RotateOnOffScript : MonoBehaviour
{
    public GameObject aud;
    AudioScript script;

    public CanvasRenderer[] ArrowCRs;

    public bool Switch = true;

    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();

        AllClear();
        ArrowCRs[0].SetAlpha(1);
        ArrowCRs[2].SetAlpha(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject) Swch();
        script.audioSource.PlayOneShot(script.sound18);
        
    }

    void Swch()
    {
        Switch = !Switch;
        
        if (Switch == true)
        {
            ArrowCRs[0].SetAlpha(1);
            ArrowCRs[1].SetAlpha(0);
        }else if (Switch == false)
        {
            ArrowCRs[0].SetAlpha(0);
            ArrowCRs[1].SetAlpha(1);
        }
    }

    public void AllClear()
    {
        foreach (CanvasRenderer nowCR in ArrowCRs)
        {
            nowCR.SetAlpha(0);
        }
    }
}
