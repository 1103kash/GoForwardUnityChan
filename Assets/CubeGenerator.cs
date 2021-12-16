using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //�L���[�u��Prefab�����邽�߂̕ϐ���p��(Inspector������)
    public GameObject cubePrefab;
    //���Ԍv���p�̕ϐ�
    private float delta = 0;
    //�L���[�u�̐����Ԋu
    private float span = 1.0f;
    //�L���[�u�̐����ʒu:X���W
    private float genPosX = 12;
    //�L���[�u�̐����ʒu�I�t�Z�b�g:Y
    private float offsetY = 0.3f;
    //�L���[�u�̏c�����̊Ԋu:Y
    private float spaceY = 6.9f;
    //�L���[�u�̐����ʒu�I�t�Z�b�g:X
    private float offsetX = 0.5f;
    //�L���[�u�̉������̊Ԋu:X
    private float spaceX = 0.4f;
    //�L���[�u�̐��������
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        //�L���[�u�̐����Ԋu�ƂȂ�span�b�ȏ�̎��Ԃ��o�߂��������ׂ�
        if(this.delta > this.span)
        {
            //���Ԍv�������Z�b�g
            this.delta = 0;
            //��������L���[�u���������_���Ɍ��߂�
            int n = Random.Range(1, this.maxBlockNum + 1);
            //��L�̌��L���[�u�𐶐�
            for(int i = 0; i < n; i++)
            {
                //�L���[�u�̐���
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * spaceY);
            }
            //���̃L���[�u�������Ԃ����߂�(�������ꂽ�L���[�u�����������A�L���[�u�̐������o���L�܂�
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
