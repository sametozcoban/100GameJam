using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderControl : MonoBehaviour
{
    public Slider slider;
    public Slider qSLider;

    public void SetPowerMaxTime(float time)
    {
        slider.maxValue = time;
        qSLider.maxValue = time;
        //slider.value = time;
    }
    public void SetQMaxTime(float time)
    {
        qSLider.maxValue = time;
    }

    public void SetQTime(float time)
    {
        qSLider.value = time;
    }
    public void SetPowerTime(float time)
    {
       
        slider.value = time;
    }
    
}
