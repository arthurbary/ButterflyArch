using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;
    public NightScreen nightScreen;
    public ScoreManager scoreManager;
    public EndManager endManager;
    public float dayDuration = 120f;
    public float nightDuration = 10f;

    private float currentTime = 0f;
    private bool isDay = true;

    void Start()
    {
        currentTime = 0f;
        isDay = true;
        sunLight.transform.rotation = Quaternion.Euler(-10f, 170f, 0f);
    }

    void Update()
    {
        if (isDay)
        {
            currentTime += Time.deltaTime;
            float sunRotationX = currentTime / dayDuration * 180f - 10f;
            sunLight.transform.rotation = Quaternion.Euler(sunRotationX, 170f, 0f);

            if (sunRotationX >= 190f)
            {
                isDay = false;
                currentTime = 0f;
                nightScreen.ShowNightScreen(nightDuration);
                StartCoroutine(CallCheckEndConditionsAfterDelay(3f));
            }
        }
    }

    public void StartNewDay()
    {
        isDay = true;
        currentTime = 0f;

        sunLight.transform.rotation = Quaternion.Euler(-10f, 170f, 0f);

        scoreManager.AddSurvivalDay();
    }

    private IEnumerator CallCheckEndConditionsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        endManager.CheckEndConditions();
    }
}
