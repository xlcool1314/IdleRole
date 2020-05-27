using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoleInfo : MonoBehaviour
{
    public Button lvUpButton;
    public Button sellButton;

    public TextMeshProUGUI describeText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI treatmentText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI lvText;

    public GameObject infoRole;

    private void Start()
    {
        lvUpButton.onClick.AddListener(LvUp);
        Debug.Log(infoRole);
    }

    public void LvUp()
    {

    }

    private void Update()
    {
        describeText.text = infoRole.GetComponent<RoleBase>().describe.ToString();
        damageText.text = infoRole.GetComponent<RoleBase>().damage[infoRole.GetComponent<RoleBase>().lv - 1].ToString();
        treatmentText.text = infoRole.GetComponent<RoleBase>().myTreatment[infoRole.GetComponent<RoleBase>().lv - 1].ToString();
        DefenseText.text = infoRole.GetComponent<RoleBase>().defense[infoRole.GetComponent<RoleBase>().lv - 1].ToString();
        HpText.text = infoRole.GetComponent<RoleBase>().maxHp[infoRole.GetComponent<RoleBase>().lv - 1].ToString();
        lvText.text = infoRole.GetComponent<RoleBase>().lv.ToString();
    }

}
