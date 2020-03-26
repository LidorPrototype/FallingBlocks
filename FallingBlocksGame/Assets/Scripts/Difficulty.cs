using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{

    public static float secondsToMaxDifficulty = 60f;

    public static void setSecondsToMaxDifficulty(float maxSeconds)
    {
        secondsToMaxDifficulty = maxSeconds;
    }

    public static float getDifficultyPrecent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
