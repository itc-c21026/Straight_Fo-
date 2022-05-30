using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*--------------------------------
 アニメーション画面のシーン遷移
--------------------------------*/

public class SceneManager2 : MonoBehaviour
{
    public GameObject aud;
    AudioScript script;

    float b;
    float c;

    int cnt;

    // Start is called before the first frame update
    void Start()
    {
        c = 0.4f;
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();

        Application.targetFrameRate = 30;
        Screen.SetResolution(1280, 800, false);
    }

    // Update is called once per frame
    void Update()
    {
        b += Time.deltaTime;
        Invoke("scene", 5f);
        if (2.15f <= b)
        {
            c -= Time.deltaTime;
            if (0f >= c && cnt < 4)
            {
                if (cnt == 3)
                {
                    script.audioSource.volume = 1;
                    script.audioSource.pitch = 1.5f;
                }
                script.audioSource.PlayOneShot(script.sound8);
                cnt++;
                c = 0.6f;
            }
        }
    }

    void scene()
    {
        SceneManager.LoadScene("MainGame");
    }
}
