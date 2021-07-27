using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class PlayerCtrler : MonoBehaviour
{

    [SerializeField]
    public float _speed;



    public bool _IsGround = true;

    RaycastHit _hit;

    //何m浮いたらジャンプとみなすか
    public float _GroundThre;

    public Rigidbody _rigidbody;

    public Ability _ability;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ability = GetComponent<Ability>();
        _GroundThre = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        Vector3 velocity = new Vector3(VRInput.LStick.x, 0, VRInput.LStick.y);
        Vector3 rotation = new Vector3(0, InputTracking.GetLocalRotation(XRNode.Head).eulerAngles.y, 0);

        _rigidbody.AddForce(transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed * Time.deltaTime), ForceMode.Acceleration);

        if (VRInput.RGripPress || VRInput.LGripPress)

        if (VRInput.RStickPush)
        {
            Debug.Log("右手武器切り替え");
        }
        if (VRInput.LStickPush)
        {
            Debug.Log("左手武器切り替え");
        }

        if (VRInput.Y)
        {
            Debug.Log("左手武器リロード");
        }
        if (VRInput.B)
        {
            Debug.Log("右手武器リロード");
        }


        // _rigidbody.position += ;
        /*
         if (!_ability._flyable)
         {
             if (VRInput.A)
             {
                 //ハイパー雑な着地判定
                 if(Physics.Raycast(transform.position - new Vector3(0,0.8f,0), Vector3.down, _GroundThre))
                 {
                     _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                 }

             }
         }
         else
         {*/

        // }

        /*
         * 緊急姿勢制御
        if (VRInput.RStickPush && transform.rotation.eulerAngles.magnitude > 15)
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }*/
        /*
        if(武器がセミオートなら)
        {
            if(VRInput.RTrigger)
            {
                射撃   
            }
            if(VRInput.LTrigger)
            {
                射撃   
            }
        }
        if(武器がフルオートなら)
        {
            if(VRInput.RTriggerPress)
            {
                射撃   
            }
            if(VRInput.LTriggerPress)
            {
                射撃   
            }
        }
        */
    }

}
