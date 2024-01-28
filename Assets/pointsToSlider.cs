using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsToSlider : MonoBehaviour
{
    Slider _slider;
    float currentPoints;
    float currentSliderValue;
    public float pointsBeforeNextWeapon=1000f;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        currentPoints = 0f;
        currentSliderValue = 0f;
    }

    void Update()
    {
        currentPoints = ScoringManager.instance.currentScore % pointsBeforeNextWeapon;
        currentSliderValue = currentPoints / pointsBeforeNextWeapon;
        _slider.value = currentSliderValue;
    }

    private void EffectWhenMaxPoints()
    {
        if (currentPoints >= pointsBeforeNextWeapon)
        {
            // Give new weapon in the list of weapons
        }
    }
}
