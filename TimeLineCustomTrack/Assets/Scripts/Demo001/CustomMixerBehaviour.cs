using UnityEngine;
using UnityEngine.Playables;

public class CustomMixerBehaviour : PlayableBehaviour
{
    private float defaultMixValue = 1;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        float mixedEndValue = 0;
        int currentInputCount = 0;
        
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight>0)
            {
                currentInputCount++;
            }
            
            ScriptPlayable<CustomBehaviour> playableInput = (ScriptPlayable<CustomBehaviour>)playable.GetInput(i);
            CustomBehaviour customBehaviour = playableInput.GetBehaviour();
            mixedEndValue = inputWeight * customBehaviour.mixParam;
        }

        if (currentInputCount == 0)
        {
            mixedEndValue = defaultMixValue;
        }
        // Debug.LogError($"mixedEndValue:{mixedEndValue}");
    }
}
