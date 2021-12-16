using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�̈ړ����x
    private float speed = -12;
    //�L���[�u�̏��ňʒu
    private float deadLine = -10;
    //AudioSource�R���|�[�l���g���擾���邽�߂̕ϐ���p��
    AudioSource cubesfx;

    // Start is called before the first frame update
    void Start()
    {
        this.cubesfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        this.gameObject.transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //��ʊO�ɏo����j��
        if(transform.position.x < this.deadLine)
        {
            Destroy(this.gameObject);
        }
    }
    //�Փˎ���Tag�𔻕ʂ��āA�n��or�L���[�u�������ꍇ�͌��ʉ����Đ�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "groundTag" || collision.gameObject.tag == "cubeTag")
        {
            this.cubesfx.Play();
        }
    }
}
