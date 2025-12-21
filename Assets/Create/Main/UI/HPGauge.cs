using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HPGauge : MonoBehaviour
{
    [SerializeField] private Image gaugeGreen;

    /// <summary>
    /// 遅れて減るゲージ
    /// </summary>
    [SerializeField] private Image gaugeRed;

    private PlayerHPScript playerHPS;
    float hpRate;

    private Sequence _barSeq;

    void Start()
    {
        GameObject obj = GameObject.Find("PlayerObserver");
        playerHPS = obj.GetComponent<PlayerHPScript>();


        hpRate = (float)playerHPS.GetHP() / 10;
        gaugeGreen.fillAmount = hpRate;
        gaugeRed.fillAmount = hpRate;
    }

    void Update()
    {
    }


    /// <summary>
    /// HPゲージに反映
    /// </summary>
    public void HPReflect()
    {
        hpRate = (float)playerHPS.GetHP() / 10;
        gaugeGreen.fillAmount = hpRate;//緑のゲージはすぐ減らす

        //赤のゲージはゆっくり減らす
        _barSeq?.Kill();
        _barSeq = DOTween.Sequence()
            .SetLink(gameObject)
            .SetDelay(0.75f)
            .Append(gaugeRed.DOFillAmount(hpRate, 0.5f));
    }
}
