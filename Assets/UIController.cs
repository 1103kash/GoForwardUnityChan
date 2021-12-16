using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //�Q�[���I�[�o�[(Text)�̃I�u�W�F�N�g���擾���邽�߂̕ϐ���p��
    private GameObject gameOverText;
    //���s����(Text)�̃I�u�W�F�N�g���擾���邽�߂̕ϐ���p��
    private GameObject runLengthText;
    //���s����
    private float len = 0;
    //���s���x
    private float speed = 5f;
    //�Q�[���I�[�o�[����
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g���擾
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[��ԂłȂ��Ƃ��͋������X�V��������
        if(this.isGameOver == false)
        {
            //���s�����̍X�V
            this.len += this.speed * Time.deltaTime;
            //���s�����̕\��
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }
        //�Q�[���I�[�o�[�ɂȂ����ꍇ
        if (this.isGameOver == true)
        {
            //�N���b�N���ꂽ��V�[�������[�h����
            if (Input.GetMouseButtonDown(0))
            {
                //SampleScene��ǂݍ���(�����[�h)
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[���ɉ�ʂɃQ�[���I�[�o�[��\��(�����̍X�V���~�߂邽��isGameOver��True�ɂ���)
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
