using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//轨道颜色
[TrackColor(1f, 0, 0)]
//Track的绑定对象类型
[TrackBindingType(typeof(Transform))]
//轨道片段
[TrackClipType(typeof(CustomClip))]
public class CustomTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var customMixerBehaviour = ScriptPlayable<CustomMixerBehaviour>.Create(graph, inputCount);//创建Clip混合器
        // var playable = ScriptPlayable<CustomBehaviour>.Create(graph, inputCount);//创建行为控制器
        
        PlayableDirector playableDirector = go.GetComponent<PlayableDirector>();            //获取director
        Transform bindTrans = playableDirector.GetGenericBinding(this) as Transform;   //获取绑定对象
        foreach (var clip in GetClips())                                                    //获取clip片段
        {
            CustomClip customClip = clip.asset as CustomClip;
            if (customClip!=null)
            {
                customClip.bindTrans = bindTrans;                                           //给clip的绑定对象赋值
            }
        }

        return customMixerBehaviour;
    }
}
