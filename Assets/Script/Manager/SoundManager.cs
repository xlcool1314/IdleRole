using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SoundManager : SingletonMono<SoundManager>
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
