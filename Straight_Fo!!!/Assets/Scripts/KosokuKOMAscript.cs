using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 ������(�R�X�g2)�̃v���O����
---------------------------------------*/

public class KosokuKOMAscript : MonoBehaviour
{
    bool col;

    private void Start()
    {
        col = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �R���C�_�ɐG��Ă���I�u�W�F�N�g��Rigitbody�R���|�[�l���g���擾
        Rigidbody r = collision.gameObject.GetComponent<Rigidbody>();

        // �{�[�����ǂ̕����ɂ��邩���v�Z
        Vector3 direction = collision.gameObject.transform.position - transform.position;
        direction.Normalize();

        // �Ԃ������I�u�W�F�N�g�̃^�O��KOMA�������ꍇ�A���̃I�u�W�F�N�g�ɔ�����^����
        if (collision.gameObject.tag == "KOMA" || collision.gameObject.tag == "KOMA2")
        {
            if (col == true)
            {
                r.velocity *= 0.9f;
                r.AddForce(direction * 20.0f, ForceMode.Impulse);
                col = false;
            }
        }
    }
}
