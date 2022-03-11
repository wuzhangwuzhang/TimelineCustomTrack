using System;
using UnityEngine;
using UnityEngine.Playables;

public class CustomBehaviour : PlayableBehaviour
{
    /// <summary>
    /// 演出控制对象
    /// </summary>
    public Transform bindTrans;

    /// <summary>
    /// 自定义参数
    /// </summary>
    public String testParam;

    public float mixParam = 1;

    /// <summary>
    /// 逐帧处理逻辑
    /// </summary>
    /// <param name="playable"></param>
    /// <param name="info"></param>
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        base.PrepareFrame(playable, info);
        // Debug.LogError($"PrepareFrame: {Time.frameCount}");
    }

    /// <summary>
    /// 逐帧处理逻辑
    /// </summary>
    /// <param name="playable"></param>
    /// <param name="info"></param>
    /// <param name="playerData"></param>
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);
        // Debug.LogError($"ProcessFrame: {Time.frameCount}");
    }

    /// <summary>
    /// Start
    /// </summary>
    /// <param name="playable"></param>
    public override void OnGraphStart(Playable playable)
    {
        base.OnGraphStart(playable);
        Debug.LogError($"OnGraphStart: {Time.frameCount}");
    }

    /// <summary>
    /// Destory
    /// </summary>
    /// <param name="playable"></param>
    public override void OnGraphStop(Playable playable)
    {
        base.OnGraphStop(playable);
        Debug.LogError($"OnGraphStop: {Time.frameCount}");
    }

    /// <summary>
    /// Awake
    /// </summary>
    /// <param name="playable"></param>
    public override void OnPlayableCreate(Playable playable)
    {
        base.OnPlayableCreate(playable);
        Debug.LogError($"OnPlayableCreate: {Time.frameCount}");
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (bindTrans)
        {
            Debug.LogError($"BindTrans：{bindTrans.name}    Param:{testParam}");
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        base.OnBehaviourPause(playable, info);
        Debug.LogError($"OnBehaviourPause: {Time.frameCount}");
    }

    /// <summary>
    /// Destroy
    /// </summary>
    /// <param name="playable"></param>
    public override void OnPlayableDestroy(Playable playable)
    {
        base.OnPlayableDestroy(playable);
        Debug.LogError($"OnPlayableDestroy: {Time.frameCount}");
    }
}