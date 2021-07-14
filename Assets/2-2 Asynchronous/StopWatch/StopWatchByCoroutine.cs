using System.Collections;   // IEnumerator を使うため
using UnityEngine;
using UnityEngine.UI;   // Text を使うため

/// <summary>
/// 「コルーチン」を使ってストップウォッチを制御するコンポーネント
/// </summary>
public class StopWatchByCoroutine : MonoBehaviour
{
    /// <summary>時間を表示する Text コンポーネント</summary>
    [SerializeField] Text m_stopWatch = default;
    /// <summary>ストップウォッチの計測値</summary>
    float m_timer = 0;
    /// <summary>実行中のコルーチン（実行していない時は null）</summary>
    Coroutine m_coroutine = null;

    /// <summary>
    /// ストップウォッチが停止していたら計測を開始し、計測中ならば計測を停止する
    /// </summary>
    public void StartPause()
    {
        if (m_coroutine == null)    // 停止している時は
        {
            // コルーチンを開始する
            m_coroutine = StartCoroutine(StartWorkingRoutine());
        }
        else
        {
            // 実行中だったら停止する
            StopCoroutine(m_coroutine);
            m_coroutine = null; // 停止中は null
        }
    }
    //停止中に Reset ボタンをクリックしたら、計測値を 0 にする
    //計測中に Reset ボタンをクリックしたら、計測を停止し、計測値を 0 にする
    //Reset ボタンをクリックして計測を停止した後、"Start / Pause" ボタンをクリックしたら計測が始まる
    /// <summary>
    /// ストップウォッチの計測を開始する
    /// </summary>
    /// <returns></returns>
    IEnumerator StartWorkingRoutine()
    {
        while (true)
        {
            m_timer += Time.deltaTime;
            m_stopWatch.text = m_timer.ToString("F2");
            yield return new WaitForEndOfFrame();   // Update() の処理が終わるまで待つ
        }
    }
    public void Reset()
    {


        m_timer = 0;

        m_stopWatch.text = m_timer.ToString("F2");
        
        
            
            StopCoroutine(m_coroutine);
           
            m_coroutine = null; 
       

    }
}
