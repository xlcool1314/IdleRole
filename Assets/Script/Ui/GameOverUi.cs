using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class GameOverUi : UIBaseBehaviour
{
    public Button button;

    public override void Clean()
    {
        button.onClick.RemoveAllListeners();
    }

    public override void Init()
    {
        button.onClick.AddListener(BackHome);
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        Init();
    }

    void BackHome()
    {
        UserAssetManager.Instance.InitInfo();
        SceneManager.LoadScene(0);
        Clean();
        Destroy(gameObject);
    }
}
