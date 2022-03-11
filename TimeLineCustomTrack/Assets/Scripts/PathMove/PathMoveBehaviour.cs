/*
 * Clip的行为控制逻辑
 */
using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Playables;

public class PathMoveBehaviour : PlayableBehaviour
{
    /// <summary>
    /// 路点
    /// </summary>
    public List<Vector3> WayPoints;
    /// <summary>
    /// 轨道的绑定对象
    /// </summary>
    public Transform TargetTrans;
    private TweenerCore<Vector3, Path, PathOptions> tweenCore;

    private readonly int run = Animator.StringToHash("Run");
    private bool isFirstFrame = true;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        PlayTweenPath(playable);
    }
    
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        DOTween.Pause("pathMove");
    }
    
    private void PlayTweenPath(Playable playable)
    {
        if (isFirstFrame)
        {
            if (0 == WayPoints.Count)
            {
                Debug.LogError("路点不存在!!!");
                return;
            }
            float timeDuration = (float)playable.GetDuration();
            // Debug.Log($"timeDuration:{timeDuration} {role?.name}");
        
            DOTweenPath tweenPath = new DOTweenPath();
            tweenPath.wps.Clear();
            tweenPath.wps = WayPoints;

            tweenCore = TargetTrans.DOPath(tweenPath.wps.ToArray(),timeDuration);
            tweenCore.OnStart(() =>
            {
                // Debug.Log("OnStart");
                TargetTrans.GetComponent<Animator>()?.SetFloat(run, 0.5f);
            });
            
            tweenCore.onPause = () =>
            {
                // Debug.Log("onPause");
                TargetTrans.GetComponent<Animator>()?.SetFloat(run,0);
            };
            
            tweenCore.onComplete = () =>
            {
                // Debug.Log("onComplete");
                TargetTrans.GetComponent<Animator>()?.SetFloat(run,0);
                TargetTrans.localRotation= Quaternion.identity;
            };
            
            tweenCore.onWaypointChange = delegate(int index)
            {
                int nextPointIds = index + 1;
                // Debug.Log($"WayPoint Index:{index} Next:{nextPointIds}");
                var nextPoint = WayPoints[nextPointIds > WayPoints.Count ? WayPoints.Count : nextPointIds];
                Vector3 vT = nextPoint - TargetTrans.localPosition;
                TargetTrans.localRotation=  Quaternion.LookRotation(vT);
            };
            tweenCore.SetId<TweenerCore<Vector3, Path, PathOptions>>("pathMove");
            isFirstFrame = false;
        }

        if (TargetTrans != null)
        {
            DOTween.Play("pathMove");    
        }
        else
        {
            Debug.LogError("role is null");
        }
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        tweenCore = null;
    }

    
}
