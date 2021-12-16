using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //Animator�R���|�[�l���g���擾���邽�߂̕ϐ���p��
    Animator animator;
    //Rigidbody���擾���邽�߂̕ϐ���p��
    Rigidbody2D rigid2D;
    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;
    //�W�����v���x����
    private float dump = 0.8f;
    //�W�����v���x
    private float jumpVelocity = 20;
    //�Q�[���I�[�o�[�ɂȂ�x���W
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();
        //Rigidbody2D�R���|�[�l���g���擾����
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animator��Controller�ő���A�j���[�V�����̑J�ڏ����ƂȂ��Ă���p�����[�^�𒲐�
        this.animator.SetFloat("Horizontal", 1);
        //���n��Ԃ𒲂ׂăp�����[�^�𒲐�(�O�����Z�q�ŕϐ������������ē��ꍞ��)
        bool isGround = (this.groundLevel < transform.position.y) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //�W�����v��Ԃł͑�����0�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        //���n��ԂŃN���b�N���ꂽ�ꍇ�A������ɗ͂�������
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        //�N���b�N����Ă��Ȃ����ɏ�����ւ̗͂��c���Ă���ꍇ����������
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if (transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���A��ʏ��GameOver�\�����������Z�̒�~
            //�� ���X�N���v�g�̊֐������Ăяo���ꍇ�́A���I�u�W�F�N�g�̃R���|�[�l���g�Ɠ����悤�Ɉ���
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //Unity������j��
            Destroy(this.gameObject);
        }
    }
}
