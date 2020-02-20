using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LossHp : MonoBehaviour
{

    public TextMeshProUGUI lossHpText;

    public int hpText;
    // Start is called before the first frame update
    void Start()
    {
        lossHpText = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lossHpText.text =hpText.ToString();
    }

    public void InitLossHpText(int hpTex)
    {
        hpText = hpTex;
    }
}
