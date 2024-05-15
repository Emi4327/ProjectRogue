using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StateHelper", menuName = "StateHelper", order = 1)]
public class StateHelperSO : ScriptableObject
{
    public AnimationClip moveLeftAnimation;
    public AnimationClip moveRightAnimation;
    public AnimationClip idleRightAnimation;
    public AnimationClip idleLeftAnimation;
}
