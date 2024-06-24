using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    private int nbCarnivores = 0, nbPlants = 0, nbHerbivores = 0;

    void Start()
    {
        CountObjects();
    }

    public void CheckEndConditions()
    {
        CountObjects();

        if (nbPlants == 0 || nbHerbivores == 0 || nbCarnivores == 0)
        {
            string gameOverMessage = "";

            if (nbPlants == 0)
                gameOverMessage = "All plants are gone! Herbivores won't have enough food to survive another night and the carnivore population will gradually shrink...";
            else if (nbHerbivores == 0)
                gameOverMessage = "All herbivores are gone! The plants will soon recover the all world. Carnivores will have to choose between becoming herbivores or dying out...";
            else if (nbCarnivores == 0)
                gameOverMessage = "All carnivores are gone! With no predators left, the herbivore population will suddenly increase, which will reduce the number of plants, leading to the end of the herbivores...";

            GameOverInfo.message = gameOverMessage;

            sceneLoader.LoadGameOver();
        }
    }

    private void CountObjects()
    {
        nbPlants = GameObject.FindGameObjectsWithTag("Plant").Length;
        nbHerbivores = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        nbCarnivores = GameObject.FindGameObjectsWithTag("Carnivore").Length;
    }
}
