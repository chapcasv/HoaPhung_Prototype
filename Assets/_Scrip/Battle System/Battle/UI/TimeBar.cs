using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeBar : MonoBehaviour
{
    [Header("Time Cowndown")]
    [SerializeField] Slider slider_time;
    private const float transitionOutBattleMode = 2f;
    private const float maxTimeStartPhase = 20f;
    private const float smooth = 100;
    private const float maxTimeDrawPhase = 20f;
    private const float maxTimeBattlePhase = 40f;

    //Dont need global variable
    public void StartPhase()
    {
        StartCoroutine(TimeStartPhase(maxTimeStartPhase, smooth));
    }

    private IEnumerator TimeStartPhase(float maxTime, float smooth)
    {
        slider_time.maxValue = maxTime;
        slider_time.value = slider_time.maxValue;
        float smoothTime = smooth * maxTime;
        float sub = slider_time.maxValue / smoothTime;
        while (slider_time.value > slider_time.minValue && BattleSystem.InStartPhase)
        {
            slider_time.value -= sub;

            yield return new WaitForSeconds(sub);
        }
        ///Auto trigger B_Confirm when over time
        if (BattleSystem.InStartPhase) { BattleUI.instance.Confirm(); }
    }

    public void DrawPhase()
    {
        StartCoroutine(TimeDrawPhase(maxTimeDrawPhase, smooth));
    }

    private IEnumerator TimeDrawPhase(float maxTime, float smooth)
    {
        slider_time.maxValue = maxTime;
        slider_time.value = slider_time.maxValue;
        float smoothTime = smooth * maxTime;
        float sub = slider_time.maxValue / smoothTime;
        while (slider_time.value > slider_time.minValue && BattleSystem.InDrawPhase)
        {
            slider_time.value -= sub;

            yield return new WaitForSeconds(sub);
        }
        BattleSystem.InDrawPhase = false;
    }

    public void BattlePhase()
    {
        StartCoroutine(TimeBattlePhase(maxTimeBattlePhase));
    }

    public IEnumerator TimeBattlePhase(float maxTimeBattle)
    {

        slider_time.maxValue = maxTimeBattle;
        slider_time.value = slider_time.maxValue;

        float sub = slider_time.maxValue / 200;

        while (slider_time.value > slider_time.minValue && BattleSystem.InBattleMode)
        {
            slider_time.value -= sub;

            yield return new WaitForSeconds(sub);
        }
        StartCoroutine(TransitionToOutBattleMode());
    }

    private IEnumerator TransitionToOutBattleMode()
    {
        slider_time.maxValue = transitionOutBattleMode;
        slider_time.value = slider_time.maxValue;

        float sub = slider_time.maxValue / 100;

        while (slider_time.value > slider_time.minValue)
        {
            slider_time.value -= sub;
            yield return new WaitForSeconds(sub);
        }
        ResetSliderTime();
    }

    private void ResetSliderTime()
    {
        slider_time.value = slider_time.maxValue;
    }
}
