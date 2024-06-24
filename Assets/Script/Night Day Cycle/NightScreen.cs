using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NightScreen : MonoBehaviour
{
    public GameObject nightScreenUI;
    public NightEvent nightEvent;
    public TMP_Text dayCountText;

    public TMP_Text nbPlantsText, diffPlantsText, nbHerbivoresText, diffHerbivoresText, nbCarnivoresText, diffCarnivoresText;
    private int dayCount = 0;
    private int nbCarnivores = 0, nbPlants = 0, nbHerbivores = 0;
    private int prev_nbPlants, prev_nbCarnivores, prev_nbHerbivores;

    void Start()
    {
        nightScreenUI.SetActive(false);
    }

    public void ShowNightScreen(float nightDuration)
    {
        CountPreviousObjects();
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

        if (prev_nbCarnivores > nbCarnivores)
            diffCarnivoresText.text = "-" + (prev_nbCarnivores - nbCarnivores).ToString();
        else
            diffCarnivoresText.text = "+" + (nbCarnivores - prev_nbCarnivores).ToString();

        if (prev_nbHerbivores > nbHerbivores)
            diffHerbivoresText.text = "-" + (prev_nbHerbivores - nbHerbivores).ToString();
        else
            diffHerbivoresText.text = "+" + (nbHerbivores - prev_nbHerbivores).ToString();

        if (prev_nbPlants > nbPlants)
            diffPlantsText.text = "-" + (prev_nbPlants - nbPlants).ToString();
        else
            diffPlantsText.text = "+" + (nbPlants - prev_nbPlants).ToString();
    }

    private void CountPreviousObjects()
    {
        prev_nbPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        prev_nbHerbivores = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        prev_nbCarnivores = GameObject.FindGameObjectsWithTag("Carnivore").Length;
    }
}
