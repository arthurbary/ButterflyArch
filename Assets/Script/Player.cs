using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private InputAction move;
    private InputAction DoAction;
    private InputAction FeedMe;
    public float speed = 10f;

    private int Food ;
    public int _Food{
                        get => Food;
                        private set{
                            _Food=value;
                        }
                    }
    private float Hunger ;
    public float _Hunger{
                        get => Hunger;
                        private set{
                            _Hunger=value;
                        }
                    }
    private int Weed;
    public int _Weed{
                        get => Weed;
                        private set{
                            _Weed=value;
                        }
                    }
    private Vector3 forward, right;
    public bool moving{get; private set;}

   private Camera cameraPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        DoAction = playerInput.actions["Action"];
        FeedMe = playerInput.actions["Feed"];
        characterController = GetComponent<CharacterController>();
        cameraPlayer = Camera.main;
        Hunger=10;
        Food =10;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Hungry());
        MovePlayer();


        if(FeedMe.ReadValue<float>()==1 && Input.GetKeyDown(KeyCode.F)){
           if (Food>0)
           {
                Feed();
            }
        }

    }

    public void MovePlayer(){
        forward= cameraPlayer.transform.forward;
        right= cameraPlayer.transform.right;
        right=Vector3.ProjectOnPlane(right,Vector3.up).normalized;
        forward=Vector3.ProjectOnPlane(forward,Vector3.up).normalized;

        Vector2 movement = move.ReadValue<Vector2>();
        moving= movement!=Vector2.zero;
        Vector3 finalMovement= movement.x * right + movement.y* forward;
        characterController.SimpleMove(finalMovement*speed);
    }
    public void Weeding(PlantPoolMember plant){
        Weed+=1;
        plant.pool.Kill( plant);
    }
    public void Hunt(CarnivorePoolMember carnivore){
        carnivore.pool.Kill(carnivore);
        Food+=1;
        carnivore.pool.Kill(carnivore);
    }
    public void Hunt(HerbivorePoolMember herbivore){
        herbivore.pool.Kill(herbivore);
        Food+=1;
        herbivore.pool.Kill(herbivore);
    }

    public void OnTriggerStay(Collider other){
        if(DoAction.ReadValue<float>()==1){
            if (other.tag=="Plant")
            {
                Weeding(other.GetComponent<PlantPoolMember>());
            }else if (other.tag=="Carnivore")
            {
                Hunt(other.GetComponent<CarnivorePoolMember>());
            }else if(other.tag=="Herbivore")
            {
                Hunt(other.GetComponent<HerbivorePoolMember>());
            }
        }
    }

    private IEnumerator Hungry(){
        if (Hunger>0)
        {
            Hunger -= 0.002f;
        }else{
            Hunger =0f;
        }
        yield return new WaitForSecondsRealtime(3600);
    }
    public void Feed()
    {
        if(Hunger<10)
        {
            Food-=1;
            if ((Hunger+1.5f) <=10f)
            {
                Hunger+=1.5f;
            }else{
                Hunger=10f;
            }
        }
    }
}
