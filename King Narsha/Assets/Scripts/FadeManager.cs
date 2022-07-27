using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour //fadeout->fadein
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;  // fadeSpeed 값이 10이면 1초(값이 클수록 빠름)
    public Image image; //검은 바탕 이미지

    private void Start()
    {
        image = GetComponent<Image>();
        FadeIn(); //씬 로드될때 fadein이 자동으로 실행됨
    }

    //싱글톤
    public static FadeManager instance;

    private void Awake()
    {
        #region 싱글톤
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
        StopAllCoroutines(); //이전에 실행중이던 코루틴 무시 
        StartCoroutine(Fade(1, 0)); //검은 배경의 알파값이 0에서 1으로(화면이 점점 밝아짐) , fadein
        Debug.Log("fadein");
    }

    public void FadeOut()
    {
        StopAllCoroutines(); //이전에 실행중이던 코루틴 무시 
        StartCoroutine(Fade(0, 1)); //검은 배경의 알파값이 0에서 1으로(화면이 점점 어두워짐) , fadeout
        Debug.Log("fadeout");
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent<1)
        {
            //fadeTime으로 나누어서 fadeTime 시간동안
            //percent값이 0에서 1로 증가하도록 함
            currentTime += UnityEngine.Time.deltaTime;
            percent = currentTime / fadeTime;

            //알파값을 start부터 end까지 fadeTime 시간동안 변화시킨다
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }
}
