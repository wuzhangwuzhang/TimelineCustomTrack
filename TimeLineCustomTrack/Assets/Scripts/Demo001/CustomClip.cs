using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CustomClip : PlayableAsset,ITimelineClipAsset
{
    /// <summary>
    /// 轨道的绑定对象
    /// </summary>
    public Transform bindTrans;
    /// <summary>
    /// 测试参数
    /// </summary>
    public String testParam;

    private readonly CustomBehaviour template = new CustomBehaviour();

    public ClipCaps clipCaps => ClipCaps.Extrapolation | ClipCaps.Blending;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<CustomBehaviour>.Create(graph,template);
        
        CustomBehaviour behaviour = playable.GetBehaviour();
        behaviour.bindTrans = bindTrans;
        behaviour.testParam = testParam;

        return playable;
    }
}