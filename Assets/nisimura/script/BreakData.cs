using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakData 
{ 
    /// <summary> 破壊率を返します(0%~100%) </summary>
    public static float BreakingPercentage { get =>　(BreakManager.Breakobj > 0 && BreakManager.Total > 0) ?  BreakManager.Breakobj * 100f / BreakManager.Total : 0; } 
    public static void ResetData() => BreakManager.Breakobj = BreakManager.Total = 0;
    
}
