using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*----------------------------------------
 �p�b�N�}��(�R�X�g3)�̃v���O����
----------------------------------------*/

public class PacManScript1 : MonoBehaviour
{
    public int cnt;

    public GameObject aud;
    AudioScript script;

    public GameObject obj;
    GameController script2;

    float b;
    private void Start()
    {
        cnt = 0;

        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();

        obj = GameObject.Find("GameObject");
        script2 = obj.GetComponent<GameController>();

        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        b += Time.deltaTime;
        if (b >= 0.3)
        {
            script.audioSource.PlayOneShot(script.sound2);
            b = 0;
        }

        if (script2.pacmanbl2_2 == true)
        {
            if (this.transform.position.x >= 0) script2.pacmanbl2_3 = true;
            script2.pacmanbl2_2 = false;
        }

        if (script2.pacmanbl2_3 == true)
        {
            this.transform.localEulerAngles = new Vector3(0, -90, 0);
            if (cnt == 3)
            {
                this.transform.position += new Vector3(0, -0.1f, 0);
            }
            else
            {
                this.transform.position += new Vector3(-0.4f, 0, 0);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // KOMA�^�O�̃I�u�W�F�N�g�ɓ��������ꍇ
        if (collision.gameObject.tag == "KOMA")
        {
            // �����邽�т�cnt��1���J�E���g����A3�����̏ꍇ���������I�u�W�F�N�g���폜����
            if (cnt < 3)
            {
                Destroy(collision.gameObject);
                script.audioSource.PlayOneShot(script.sound3);
            }
            cnt += 1;
        }
    }
}
