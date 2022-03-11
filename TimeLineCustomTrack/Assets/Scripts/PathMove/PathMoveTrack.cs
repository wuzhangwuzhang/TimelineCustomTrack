/*
 * 创建自定义轨道
 */

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//轨道颜色
[TrackColor(0.875f, 0.5944853f, 0.1737132f)]
//Track的绑定对象类型
[TrackBindingType(typeof(Transform))]
//绑定的轨道clip
[TrackClipType(typeof(PathMoveClip))]
public class PathMoveTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        PlayableDirector playableDirector = go.GetComponent<PlayableDirector>();

        var playable = ScriptPlayable<PathMoveMixerBehaviour>.Create(graph, inputCount);

        Transform role = (Transform) playableDirector.GetGenericBinding(this);
        foreach (var clip in GetClips())
        {
            var temClip = clip.asset as PathMoveClip;
            if (!(temClip is null))
                temClip.bindingTarget = role;
        }

        return playable;
    }
}