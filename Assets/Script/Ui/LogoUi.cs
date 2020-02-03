using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class LogoUi : UIBaseBehaviour
{

    public Button playbutton;

    public override void Clean()
    {
        playbutton.onClick.RemoveAllListeners();
    }

    public override void Init()
    {
       playbutton.onClick.AddListener(CreatFightUi);
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    
    public void CreatFightUi()
    {
        Addressables.InstantiateAsync("FightUi", transform.parent);
        Addressables.InstantiateAsync("HomeUi", transform.parent);
        Clean();
        Destroy(gameObject);
    }
}
