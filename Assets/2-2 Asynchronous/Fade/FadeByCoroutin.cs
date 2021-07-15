using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeByCoroutin : MonoBehaviour
{
    [SerializeField] float m_fadeTime = 1;
    [SerializeField] Image m_fadeImage = default;
    float m_timer = 0;
    /// <summary>実行中のコルーチン（実行していない時は null）</summary>
    Coroutine m_coroutine = null;
    public void StartPause()
    {
        if (m_coroutine == null)    // 停止している時は
        {
            // コルーチンを開始する
            m_coroutine = StartCoroutine(Fadeout());
            Fadeout();
        }
       
    }
    IEnumerator Fadeout ()
    {
        StartWorkingRoutine();
        m_timer += Time.deltaTime;
        Color c = m_fadeImage.color;
        c.a = m_timer / m_fadeTime;
        m_fadeImage.color = c;
        
        if (m_timer > m_fadeTime)
        {
            // フェード完了
            OnFadeFinished();
        }
        yield return null;
    }
    void Start()
    {
       
        
    }

    IEnumerator StartWorkingRoutine()
    {
        
            m_timer += Time.deltaTime;
            
            yield return new WaitForEndOfFrame();   // Update() の処理が終わるまで待つ
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFadeFinished()
    {
        Debug.Log("Fade 完了");
    }
}
