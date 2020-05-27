using System.Collections;
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
        GameObject go= Instantiate(ResourcesManager.Instance.roleInfo, transform.position,Quaternion.identity,GameObject.Find("GameMain").transform);
        go.GetComponent<RoleInfo>().infoRole = gameObject;
    }
}
