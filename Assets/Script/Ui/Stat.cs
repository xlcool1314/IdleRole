using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;//进度条的图片

    private float currentfill;

    public float MyMaxValue{get;set;}

    private float currentValue;
    public float CurrentValue 
    { 
        get 
        {
            return currentValue;
        } 
        set 
        {
            if(value>MyMaxValue)
            {
              currentValue=MyMaxValue;
            }
            else if(value<0)
            {
              currentValue=0;
            }
            else
            {
              currentValue=value;
            }

            currentfill=currentValue/MyMaxValue;
        }
    }

    

    private void Start() 
    {
        content=transform.GetComponent<Image>();
    }

    void Update()
    {
      content.fillAmount=currentfill;
    }

    public void Initialize(float currentVal,float maxValue)
    {
        MyMaxValue=maxValue;
        currentValue=currentVal;
    }


}
