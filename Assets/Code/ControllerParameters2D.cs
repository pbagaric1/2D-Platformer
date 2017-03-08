using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ControllerParameters2D 
{
    public enum JumpBehavior
    {
        CanJumpOnGround,
        CanJumpAnywhere,
        CantJump //for example water
    }

    public Vector2 MaxVelocity = new Vector2(float.MaxValue, float.MaxValue);

    [Range(0, 90)]
    public float SlopeLimit = 30; //angle

    public float Gravity = -25f; //-25 units in y direction applied to char velocity

    public JumpBehavior JumpRestrictions;

    public float JumpFrequency = .25f; //how often can our character jump

    public float JumpMagnitude = 12; //how much magnitude is going to be added to velocity
}
