﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleWindowInfo : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(LvUp);
    }

    public void LvUp()
    {
        transform.GetComponent<RoleBase>().lv += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}