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
    float speed = 2f;

    [Range(1, 100)]public int Hunger ;
    [Range(1, 100)]public int Thirst;

    private Vector3 forward, right;
    public bool moving{get; private set;}

   private Camera cameraPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        DoAction = playerInput.actions["Action"];
        characterController = GetComponent<CharacterController>();
        cameraPlayer = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

   
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
    public void Weeding(GameObject gameObject){
        Destroy(gameObject);
    }
    public void Hunt(GameObject gameObject){
        Destroy(gameObject);  
    }

    public void OnTriggerStay(Collider other){
        if(DoAction.ReadValue<float>()==1){
            if (other.tag=="Weeds")
            {
                Weeding(other.gameObject);
            }else if (other.tag=="Animals")
            {                
                Hunt(other.gameObject);
            }
        }
    }
}