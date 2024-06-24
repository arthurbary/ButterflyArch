using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightEvent : MonoBehaviour
{
    [SerializeField] PlantFactory plants;
    [SerializeField] HerbivoreFactory herbivores;
    [SerializeField] CarnivoreFactory carnivores;
    float nbPlants;
    float nbHerbivores;
    float nbCarnivores;

    public void  Night_Time()
    {
        nbPlants=GameObject.FindGameObjectsWithTag("Plant").Length;
        nbHerbivores=GameObject.FindGameObjectsWithTag("Herbivore").Length;
        nbCarnivores=GameObject.FindGameObjectsWithTag("Carnivore").Length;
        FeedTime();
        nbPlants=GameObject.FindGameObjectsWithTag("Plant").Length;
        nbHerbivores=GameObject.FindGameObjectsWithTag("Herbivore").Length;
        nbCarnivores=GameObject.FindGameObjectsWithTag("Carnivore").Length;
        Reproduction();
    }
    private void FeedTime()
    {
        if(nbHerbivores <= nbCarnivores/4){
            carnivores.Dies((int)(nbCarnivores-nbHerbivores*4));
            nbHerbivores= GameObject.FindGameObjectsWithTag("Carnivore").Length;
            herbivores.Dies((int)nbHerbivores);
        }else{
            herbivores.Dies((int) nbCarnivores/4);
        }

        if(nbPlants <= nbHerbivores/2){
            herbivores.Dies((int) (nbHerbivores-nbPlants*2));
            nbHerbivores= GameObject.FindGameObjectsWithTag("Herbivore").Length;
            plants.Dies((int)nbPlants);
        }else{
            plants.Dies((int) nbHerbivores/2);
        }

    }
    private void Reproduction(){
        if (nbCarnivores > 1)
        {
            if (nbCarnivores%2==0)
            {
                carnivores.CarnivoreReproduction(Random.Range(1,nbCarnivores/2)+1);
            }else{
                carnivores.CarnivoreReproduction(Random.Range(0,nbCarnivores/2));
            }
        }
        Debug.Log("nbHerbivore:"+nbHerbivores);
        if (nbHerbivores > 1)
        {
            if (nbHerbivores%2==0)
            {
                herbivores.HerbivoreReproduction(Random.Range(0,nbHerbivores/2)+1);
            }else{
                herbivores.HerbivoreReproduction(Random.Range(0,nbHerbivores/2));
            }
        }

        if (nbPlants > 1)
        {
            if (nbPlants%2==0)
            {
                plants.PlantReproduction(Random.Range(0,(nbPlants/2)+1));
            }else{
                plants.PlantReproduction(Random.Range(0,nbPlants/2));
            }
        }

    }

}
