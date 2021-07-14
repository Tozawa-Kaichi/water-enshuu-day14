﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 「タイマー」を使ってフェードアウトを実現するコンポーネント
/// 適当なオブジェクトに追加して使う
/// </summary>
public class FadeByTimer : MonoBehaviour
{
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float m_fadeTime = 1;
    /// <summary>フェードアウトが完了したら鳴らす音/summary>
    [SerializeField] AudioClip m_buzzer = default;
    float m_timer = 0;
    /// <summary>true の時フェード中を表すフラグ</summary>
    bool m_fade = false;

    void Update()
    {
        if (m_fade)
        {
            // Image から Color を取得し、時間の進行に合わせたアルファを設定して Image に戻す
            m_timer += Time.deltaTime;
            Color c = m_fadeImage.color;
            c.a = m_timer / m_fadeTime;
            m_fadeImage.color = c;

            if (m_timer > m_fadeTime)
            {
                // フェード完了
                OnFadeFinished();
            }
        }
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void Fade()
    {
        m_fade = true;
        Debug.Log("Fade 開始");
    }

    /// <summary>
    /// フェードアウトが終わった時に呼び出す
    /// </summary>
    void OnFadeFinished()
    {
        m_fade = false;
        Debug.Log("Fade 完了");
        AudioSource.PlayClipAtPoint(m_buzzer, Camera.main.transform.position);


    }

    //PanelForFade オブジェクトの Animator コンポーネントを無効にする
//これをしないと、スクリプトから Color を操作することができない
//シーン Fade にボタンを追加する
//新たに FadeByCoroutine スクリプトを作り、任意の GameObject にアタッチする
//FadeByCoroutine スクリプトに以下の機能を作る
//コルーチンを使って PanelForFade オブジェクトの Image コンポーネント - Color プロパティを徐々に変更して、徐々に透明から黒になる機能
//完全に黒になったら、ログを出力する
//ボタンをクリックしたらフェードするように Hierarchy を構成する
//ボタンの２度押しはできないようにすること






}
