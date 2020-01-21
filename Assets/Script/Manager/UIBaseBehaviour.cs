using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class UIBaseBehaviour : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public abstract Task Init();
    public abstract void UpdateInfo(float deltaTime);
    public abstract void Clean();
}
