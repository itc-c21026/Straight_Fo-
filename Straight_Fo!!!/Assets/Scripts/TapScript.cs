using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*----------------------------------------
 �^�b�v�G�t�F�N�g�̃v���O����
----------------------------------------*/
public class TapScript : MonoBehaviour
{
    public GameObject aud;
    AudioScript script;

    public GameObject prefab;
    public float deleteTime;

    private void Start()
    {
        deleteTime = 0.5f;
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();
    }

    // Update is called once per frame
    void Update()
    {

        Touch[] touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
        {
            Touch t = touches[i];
            var touch = Input.touches[i];

            if (Input.GetMouseButtonDown(0))
            {
                script.audioSource.PlayOneShot(script.sound12);
                //�}�E�X�J�[�\���̈ʒu���擾�B
                var touchPosition = Input.mousePosition;
                touchPosition.z = 3f;
                touchPosition.x = touch.position.x;
                touchPosition.y = touch.position.y;
                GameObject clone = Instantiate(prefab, Camera.main.ScreenToWorldPoint(touchPosition),
                    Quaternion.identity);
                if (touchPosition.x < 640)
                {
                    clone.transform.Rotate(new Vector3(0, 90, 0));
                }
                else if (touchPosition.x >= 640)
                {
                    clone.transform.Rotate(new Vector3(0, -90, 0));
                }
                Destroy(clone, deleteTime);
            }
        }
    }
}
