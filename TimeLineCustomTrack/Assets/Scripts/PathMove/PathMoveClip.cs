﻿/*
 * 轨道上的clip片段
 */

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class PathMoveClip : PlayableAsset
{
#if UNITY_EDITOR
    [Header("编辑器下路径编辑")]
    public ExposedReference<DOTweenPath> tweenPath;
#endif
    
    //ExposedReference的作用，如果没有ExposedReference的话，你是不可以引用Scene里面的引用的（只可以从Assets的东西进来）
    [Header("这里是复制过来的编辑路点")]
    public List<Vector3> wayPoints;
    [Header("被控制的轨道对象")]
    public Transform bindingTarget;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<PathMoveBehaviour>.Create(graph);
        PathMoveBehaviour behaviour = playable.GetBehaviour();
        behaviour.WayPoints = wayPoints;
        behaviour.TargetTrans = bindingTarget;
        return playable;
    }
}