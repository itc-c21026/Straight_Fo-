using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*-----------------------------------
 龍側のスコアゲージのプログラム
-----------------------------------*/

public class scoreSliderscript : MonoBehaviour
{
    public GameObject obj;
    GameController script;

    public GameObject aud;
    AudioScript script2;

    public GameObject sli;
    scoreSliderscript1 script3;

    public Image img;

    public Text textUI;

    public Slider slider;

    float b;

    bool a;

    float c;
    // Start is called before the first frame update
    void Start()
    {
        a = true;

        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<GameController>();

        aud = GameObject.Find("Audio_Sub");
        script2 = aud.GetComponent<AudioScript>();

        sli = GameObject.Find("Slider1");

        slider.value = 0;

        img.enabled = false;

        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = script.b;
        if (script.b >= 0.1f && script.b <= 5f)
        {
            if (script.S1 == true)
            {
                c += Time.deltaTime;
                if (c >= 0.28f)
                {
                    script2.audioSource.PlayOneShot(script2.sound13);
                    c = 0;
                }
            }
        }else if(script.b >= 5f && script.b <= 10f)
        {
            if (script.S1 == true)
            {
                c += Time.deltaTime;
                if (c >= 0.28f)
                {
                    script2.audioSource.PlayOneShot(script2.sound14);
                    c = 0;
                }
            }
        }else if(script.b >= 10f && script.b < 15f)
        {
            if (script.S1 == true)
            {
                c += Time.deltaTime;
                if (c >= 0.28f)
                {
                    script2.audioSource.PlayOneShot(script2.sound15);
                    c = 0;
                }
            }
        }

        if (slider.value >= 15)
        {
            if (a == true)
            {
                script2.audioSource.PlayOneShot(script2.sound11);
                a = false;
            }
            img.enabled = true;
            b += Time.deltaTime;
            if (b >= 15)
            {
                SceneManager.LoadScene("Title");
            }
            obj.GetComponent<GameController>().enabled = false;
            sli.GetComponent<scoreSliderscript1>().enabled = false;
        }
    }
}
