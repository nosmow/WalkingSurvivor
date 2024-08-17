using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int hp = 100;
    [SerializeField] private Slider hpSlider;

    private void Start()
    {
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
    }

    public void ReceiveDamage(int damage)
    {
        hp -= damage;
        hpSlider.value = hp;
    }
}
