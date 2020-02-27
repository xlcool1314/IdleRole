using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationUi : MonoBehaviour
{
    public Image betterRole;

    public Image role01_Skin;

    public Image role02_Skin;

    public Image role03_Skin;

    Animator myAnimator;

    private int overTime;

    private void Start()
    {
        //myAnimator = GetComponent<Animator>();
        DeleteMySelf();
    }

    void DeleteMySelf()
    {
        Destroy(gameObject, 4f);
    }
}
