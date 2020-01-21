using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameMangerBehavaiour : MonoBehaviour
{

    /// <summary>
    /// 初始化游戏
    /// </summary>
    /// <returns></returns>
    public virtual Task Init() { return null; }

    /// <summary>
    /// 开始一局
    /// </summary>
    /// <returns></returns>
    public virtual Task StartGame() { return null; }

    /// <summary>
    /// 游戏结束, 这里并没有清理内容，还在等待玩家确认游戏结果
    /// </summary>
    /// <returns></returns>
    public virtual Task EndGame() { return null; }

    /// <summary>
    /// 清理游戏资源
    /// </summary>
    /// <returns></returns>
    public virtual Task GameClean() { return null; }

    /// <summary>
    /// 对局逻辑循环
    /// </summary>
    /// <returns></returns>
    public virtual Task UpdateGameLoop(float deltaTime) { return null; }

    /// <summary>
    /// 全局Update
    /// </summary>
    /// <returns></returns>
    public virtual Task UpdateLoop() { return null; }

    /// <summary>
    /// 全局LateUpdate
    /// </summary>
    /// <returns></returns>
    public virtual Task LateUpdateLoop() { return null; }
}


public class SingletonMono<T> : GameMangerBehavaiour where T : GameMangerBehavaiour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();

                if (instance == null)
                {
                    //Debug.Log($"Instancing MonoBehaviour: <color=#00ff00>{typeof(T)}</color>");
                    GameObject go = new GameObject("Temp");
                    instance = go.AddComponent<T>();
                    go.name = instance.GetType().FullName;
                }
            }

            return instance;
        }
    }
}

