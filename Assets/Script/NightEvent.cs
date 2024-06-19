using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightEvent 
{
    [SerializeField] PlantFactory plants;
    [SerializeField] HerbivoreFactory herbivores;
    // [SerializeField] CarnivoreFactory carnivores;
    int nbPlants;
    int nbHerbivores;
    int nbCarnivores;
    
    public void  Night_Time()
    {
       nbPlants=GameObject.FindGameObjectsWithTag("Plant").Length;
       nbHerbivores=GameObject.FindGameObjectsWithTag("Herbivore").Length;
    //    nbCarnivores=GameObject.FindGameObjectsWithTag("Carnivore").Length;



    } 


    private void Reproduction(){
        // if (nbCarnivores%2==0)
        // {
        //     Carnivores.CarnivoreReproduction(Random.Range(0,nbCarnivores/2)+1);            
        // }else{
        //     Carnivores.CarnivoreReproduction(Random.Range(0,nbCarnivores/2));
        // }
        if (nbHerbivores%2==0)
        {
            herbivores.HerbivoreReproduction(Random.Range(0,nbHerbivores/2)+1);            
        }else{
            herbivores.HerbivoreReproduction(Random.Range(0,nbHerbivores/2));
        }
        if (nbPlants%2==0)
        {
            plants.PlantReproduction(Random.Range(0,nbPlants/2)+1);            
        }else{
            plants.PlantReproduction(Random.Range(0,nbPlants/2));
        }
        
        
    }

}
