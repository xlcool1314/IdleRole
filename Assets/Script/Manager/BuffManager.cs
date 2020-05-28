using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BuffManager : SingletonMono<BuffManager>
{
    public Dictionary<BuffType, SkillDesc> skillDic = new Dictionary<BuffType, SkillDesc>();

    public SkillConfigData skillconfigData;

    public async override Task Init()
    {
        skillconfigData = await Addressables.LoadAssetAsync<SkillConfigData>("SkillConfigData").Task;
        foreach (var skill in skillconfigData.skills)
        {
                skillDic.Add(skill.buff, skill);
        }
    }
}
