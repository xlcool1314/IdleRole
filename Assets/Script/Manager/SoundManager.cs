using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SoundManager : SingletonMono<SoundManager>
{
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
    }

    public async void Play(string name, Vector3 pos)
    {
        var clip = await Addressables.LoadAssetAsync<AudioClip>(name).Task;
        AudioSource.PlayClipAtPoint(clip, pos);
    }

    public async void PlayBGM(string name)
    {
        audioSources[0].clip = await Addressables.LoadAssetAsync<AudioClip>(name).Task;
        audioSources[0].Play();
        audioSources[0].loop = true;
    }

    public async void PlaySound(string name)
    {
        audioSources[1].clip = await Addressables.LoadAssetAsync<AudioClip>(name).Task;
        audioSources[1].Play();
        audioSources[1].loop = false;
    }

    public void Mute(bool val)
    {
        audioSources[0].mute = val;
    }
}
