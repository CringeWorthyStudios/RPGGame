using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{


    public Slider manaSlider;
    public Gradient manaGradient;
    public Image manaFill;


    public void SetMana(float mana)
    {
        manaSlider.value = mana;

        manaFill.color = manaGradient.Evaluate(manaSlider.normalizedValue);
    }

    public void SetMaxMana(float mana)
    {
        manaSlider.maxValue = mana;
        manaSlider.value = mana;

        manaFill.color = manaGradient.Evaluate(1f);
    }

}