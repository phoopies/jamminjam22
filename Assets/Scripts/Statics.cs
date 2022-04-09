using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    public static float Map(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

    public static float MapClamped(float val, float in1, float in2, float out1, float out2)
    {
        float clamped = Map(val, in1, in2, out1, out2);
        return Mathf.Clamp(clamped, out1, out2);
    }
}
