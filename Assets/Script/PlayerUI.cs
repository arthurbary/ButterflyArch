using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerUI : MonoBehaviour
{
    [SerializeField]Player player;
    [SerializeField]TMP_Text food;
    [SerializeField]TMP_Text hunger;
    // Start is called before the first frame update
    void Start()
    {
        food.SetText($"{player._Food}");
        hunger.SetText("100 %");

    }

    // Update is called once per frame
    void Update()
    {
        food.SetText($"{player._Food}");
        hunger.SetText($"{(int)(player._Hunger*10)} %");

    }
}
