using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*---------------------------------
 メニュー画面(タイトル画面)のシーン遷移
---------------------------------*/

public class SceneManagerScript : MonoBehaviour
{

    public GameObject aud;
    AudioScript script;

    public GameObject obj;

    float b;

    bool a;

    private void Start()
    {
        a = true;
        b = 1.8f;
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();

        obj = GameObject.Find("End");

        Application.targetFrameRate = 30;
        Screen.SetResolution(1280, 800, false);
    }

    public void Update()
    {
        if (a == true)
        {
            b += Time.deltaTime;
            if (b >= 4f)
            {
                script.audioSource.PlayOneShot(script.sound9);
                b = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KOMA")
        {
            obj.SetActive(false);
            a = false;
            script.audioSource.volume = 0.8f;
            script.audioSource.PlayOneShot(script.sound9);
            Invoke("scene", 3f);
        }
    }

    void scene()
    {
        SceneManager.LoadScene("Animation");
    }
}
