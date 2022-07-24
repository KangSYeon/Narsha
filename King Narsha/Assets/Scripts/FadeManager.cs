using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour //fadeout->fadein
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;  // fadeSpeed ���� 10�̸� 1��(���� Ŭ���� ����)
    public Image image; //���� ���� �̹���

    private void Start()
    {
        image = GetComponent<Image>();
        FadeIn(); //�� �ε�ɶ� fadein�� �ڵ����� �����
    }

    //�̱���
    public static FadeManager instance;

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
    }

    

    public void FadeIn()
    {
        StopAllCoroutines(); //������ �������̴� �ڷ�ƾ ���� 
        StartCoroutine(Fade(1, 0)); //���� ����� ���İ��� 0���� 1����(ȭ���� ���� �����) , fadein
        Debug.Log("fadein");
    }

    public void FadeOut()
    {
        StopAllCoroutines(); //������ �������̴� �ڷ�ƾ ���� 
        StartCoroutine(Fade(0, 1)); //���� ����� ���İ��� 0���� 1����(ȭ���� ���� ��ο���) , fadeout
        Debug.Log("fadeout");
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent<1)
        {
            //fadeTime���� ����� fadeTime �ð�����
            //percent���� 0���� 1�� �����ϵ��� ��
            currentTime += UnityEngine.Time.deltaTime;
            percent = currentTime / fadeTime;

            //���İ��� start���� end���� fadeTime �ð����� ��ȭ��Ų��
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }
}
