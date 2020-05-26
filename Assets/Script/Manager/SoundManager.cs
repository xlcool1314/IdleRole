using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SoundManager : SingletonMono<SoundManager>
{
    AudioSource audioSource;
    public override Task Init()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayBGM("Happy_new_year");
        return null;
    }

    public async void Play(string name, Vector3 pos)
    {
        var clip = await Addressables.LoadAssetAsync<AudioClip>(name).Task;
        AudioSource.PlayClipAtPoint(clip, pos);
    }

    public async void PlayBGM(string name)
    {
        audioSource.clip = await Addressables.LoadAssetAsync<AudioClip>(name).Task;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void Mute(bool val)
    {
        audioSource.mute = val;
    }
}
