using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NightScreen : MonoBehaviour
{
    public GameObject nightScreenUI;
    public NightEvent nightEvent;
    public TMP_Text dayCountText;
    public TMP_Text nbPlantsText;
    public TMP_Text nbCarnivoresText;
    public TMP_Text nbHerbivoresText;
    private int dayCount = 0;
    private int nbCarnivores = 0;
    private int nbHerbivores = 0;
    private int nbPlants = 0;


    void Start()
    {
        nightScreenUI.SetActive(false);
    }

    public void ShowNightScreen(float nightDuration)
    {
        dayCount++;
        dayCountText.text = "End of day " + dayCount.ToString();
        nightScreenUI.SetActive(true);

        if (nightEvent != null)
            nightEvent.Night_Time();
        else
            Debug.Log("Error: NightEvent == null");

        SetText();

        StartCoroutine(NightCoroutine(nightDuration));
    }

    private IEnumerator NightCoroutine(float nightDuration)
    {
        yield return new WaitForSeconds(nightDuration);
        nightScreenUI.SetActive(false);
        FindObjectOfType<DayNightCycle>().StartNewDay();
    }

    private void CountObjects()
    {
        nbPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        nbHerbivores = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        nbCarnivores = GameObject.FindGameObjectsWithTag("Carnivore").Length;
    }

    private void SetText()
    {
        CountObjects();

        nbPlantsText.text = nbPlants.ToString();
        nbHerbivoresText.text = nbHerbivores.ToString();
        nbCarnivoresText.text = nbCarnivores.ToString();
    }
}
