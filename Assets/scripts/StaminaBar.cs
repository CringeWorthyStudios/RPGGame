using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{


    public Slider staminaSlider;
    public Gradient staminaGradient;
    public Image staminaFill;


    public void SetStamina(float stamina)
    {
        staminaSlider.value = stamina;

        staminaFill.color = staminaGradient.Evaluate(staminaSlider.normalizedValue);
    }

    public void SetMaxStamina(float stamina)
    {
        staminaSlider.maxValue = stamina;
        staminaSlider.value = stamina;

        staminaFill.color = staminaGradient.Evaluate(1f);
    }

}