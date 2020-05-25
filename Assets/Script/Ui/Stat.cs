using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public Image content;//进度条的图片

    public float currentfill;//进度条的float值

    public float MyMaxValue;//最大的进度条数值

    private float currentValue;//当前进度数值
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
            currentfill=currentValue/MyMaxValue;//进度数值换算成小数
        }
    }
    private void Start() 
    {
       content=transform.GetComponent<Image>();
    }

    void Update()
    {
        if (currentfill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentfill, Time.deltaTime * 5f);
        }
        
    }

    public void Initialize(float currentVal,float maxValue)//初始化进度条
    {
        MyMaxValue=maxValue;
        currentValue=currentVal;
    }


}
