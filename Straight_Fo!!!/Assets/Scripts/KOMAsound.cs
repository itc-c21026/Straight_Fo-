using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------
 ‹î“¯Žm‚ª‚Ô‚Â‚©‚Á‚½‚Æ‚«‚Ì‰¹
------------------------------*/

public class KOMAsound : MonoBehaviour
{
    public GameObject aud;
    AudioScript script;

    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KOMA" || collision.gameObject.tag == "KOMA2")
        {
            script.audioSource.PlayOneShot(script.sound20);
        }
    }
}
