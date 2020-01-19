using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    public void Gust(){
        Debug.Log("test");
        Hid();
    }

    void Hid(){
        Debug.Log("hello");
    }

}
