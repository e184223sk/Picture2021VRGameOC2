using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{

    public static Vector2 LStick { get { return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick); } }
    public static Vector2 RStick { get { return OVRInput.Get(OVRInput.RawAxis2D.RThumbstick); } }

    #region GetDown
    public static bool A { get { return OVRInput.GetDown(OVRInput.RawButton.A); } }
    public static bool B { get { return OVRInput.GetDown(OVRInput.RawButton.B); } }
    public static bool X { get { return OVRInput.GetDown(OVRInput.RawButton.X); } }
    public static bool Y { get { return OVRInput.GetDown(OVRInput.RawButton.Y); } }
    public static bool RGrip { get { return OVRInput.GetDown(OVRInput.RawButton.RHandTrigger); } }
    public static bool LGrip { get { return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger); } }

    public static bool RTrigger { get { return OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger); } }
    public static bool LTrigger { get { return OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger); } }

    #endregion

    #region Press
    public static bool APress { get { return OVRInput.Get(OVRInput.RawButton.A); } }
    public static bool BPress { get { return OVRInput.Get(OVRInput.RawButton.B); } }
    public static bool XPress { get { return OVRInput.Get(OVRInput.RawButton.X); } }
    public static bool YPress { get { return OVRInput.Get(OVRInput.RawButton.Y); } }
    public static bool RGripPress { get { return OVRInput.Get(OVRInput.RawButton.RHandTrigger); } }
    public static bool LGripPress { get { return OVRInput.Get(OVRInput.RawButton.LHandTrigger); } }
    public static bool RTriggerPress { get { return OVRInput.Get(OVRInput.RawButton.RIndexTrigger); } }
    public static bool LTriggerPress { get { return OVRInput.Get(OVRInput.RawButton.LIndexTrigger); } }

    #endregion

    #region Position
    static GameObject RHandObj, LHandObj;

    private void Start()
    {
        RHandObj = GameObject.Find("RightHandAnchor");
        LHandObj = GameObject.Find("LeftHandAnchor");
    }
    public static Transform LHandPos { get { return LHandObj.transform; } }

    public static Transform RHandPos { get { return RHandObj.transform; } }

    #endregion

}

