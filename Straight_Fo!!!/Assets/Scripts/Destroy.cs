using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------
 �I�u�W�F�N�g���폜����v���O����
------------------------------------*/

public class Destroy : MonoBehaviour
{
    public GameObject obj;
    CardMoveScript script;
    GameController script2;

    private void Start()
    {
        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<CardMoveScript>();
        script2 = obj.GetComponent<GameController>();
    }

    // �^�O��KOMA�ƂԂ������ꍇ�A���̃I�u�W�F�N�g���폜�����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KOMA" || other.gameObject.tag == "KOMA2")
        {
            Destroy(other.gameObject);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        // �^�O��TRACK�̃I�u�W�F�N�g�ƂԂ������ꍇ�A���̃I�u�W�F�N�g��������
        // script...�͑��̃v���O����
        if (collision.gameObject.tag == "TRACK")
        {
            Destroy(collision.gameObject);
            script2.trackbl2 = false;
            script2.trackbl3 = false;
        }

        // �^�O��TRACK2�A��L�Ɠ����v���O����
        if (collision.gameObject.tag == "TRACK2")
        {
            Destroy(collision.gameObject);
            script2.trackbl2_2 = false;
            script2.trackbl2_3 = false;
        }

        // �^�O��PACMAN�A��L�Ɠ����v���O����
        if (collision.gameObject.tag == "PACMAN")
        {
            Destroy(collision.gameObject);
            script2.pacmanbl2 = false;
            script2.pacmanbl3 = false;
        }

        // �^�O��PACMAN2�A��L�Ɠ����v���O����
        if (collision.gameObject.tag == "PACMAN2")
        {
            Destroy(collision.gameObject);
            script2.pacmanbl2_2 = false;
            script2.pacmanbl2_3 = false;
        }

        // �^�O��KOMA�EKOMA2�A��L�Ɠ����v���O����
        if (collision.gameObject.tag == "KOMA" || collision.gameObject.tag == "KOMA2" || collision.gameObject.tag == "BOM")
        {
            Destroy(collision.gameObject);
        }
    }
}
