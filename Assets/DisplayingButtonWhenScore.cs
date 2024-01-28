using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class DisplayingButtonWhenScore : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public pointsToSlider SliderInfo;
    private float sliderValueMax;
    
    // Start is called before the first frame update
    void Start()
    {
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false); 
        Item4.SetActive(false);

        sliderValueMax = SliderInfo.pointsBeforeNextWeapon;

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoringManager.instance.currentScore >= sliderValueMax)
        {
            Item1.SetActive(true);
        }
        if (ScoringManager.instance.currentScore >= 2*sliderValueMax)
        {
            Item2.SetActive(true);
        }
        if (ScoringManager.instance.currentScore >= 3*sliderValueMax)
        {
            Item3.SetActive(true);
        }
        if (ScoringManager.instance.currentScore >= 4* sliderValueMax)
        {
            Item4.SetActive(true);
        }
    }
}
