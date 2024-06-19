using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NightScreen : MonoBehaviour
{
    public GameObject nightScreenUI;
    public TMP_Text dayCountText;
    private int dayCount = 0;

    void Start()
    {
        nightScreenUI.SetActive(false);
    }

    public void ShowNightScreen(float nightDuration)
    {
        dayCount++;
        dayCountText.text = "End of day " + dayCount.ToString();
        nightScreenUI.SetActive(true);
        StartCoroutine(NightCoroutine(nightDuration));
    }

    private IEnumerator NightCoroutine(float nightDuration)
    {
        yield return new WaitForSeconds(nightDuration);
        nightScreenUI.SetActive(false);
        FindObjectOfType<DayNightCycle>().StartNewDay();
    }
}
