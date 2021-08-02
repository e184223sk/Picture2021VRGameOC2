using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class PlayerCtrler : MonoBehaviour
{

    [SerializeField]
    public float _speed;

    public float _MaxSpeed;

    public float _flyDevide;
    

    [SerializeField]
    public float _jumpForce;


    //何m浮いたらジャンプとみなすか
    public float _GroundThre;

    public static bool _IsGround = false;

    public Collider _footCol;

    public Rigidbody _rigidbody;

    public Ability _ability;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ability = GetComponent<Ability>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    RaycastHit hit;

    public void PlayerMove()
    {

        Debug.Log(_IsGround);

        Vector3 velocity = new Vector3(VRInput.LStick.x, 0, VRInput.LStick.y);
        Vector3 rotation = new Vector3(0, InputTracking.GetLocalRotation(XRNode.Head).eulerAngles.y, 0);

        //移動
        //スピードアップアビリティを使ってない時 速度制限
        if (!Ability._SpeedUPEnable && !Ability._IsUsing)
        {
            if (_rigidbody.velocity.magnitude < _MaxSpeed)
                _rigidbody.AddForce(transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed * Time.deltaTime), ForceMode.Force);
        }
        else
        {
            _rigidbody.AddForce(transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed * Time.deltaTime), ForceMode.Force);
        }

        if (Ability._FlyEnable)
        {
            if ( Ability._IsUsing && VRInput.RGripPress)
            {
                _rigidbody.AddForce((Vector3.up  *_jumpForce  / _flyDevide) ,ForceMode.Acceleration);
            }
            if(!Ability._IsUsing && VRInput.RGrip)
            {
                if (_IsGround)
                {
                    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                }
            }
        }
        else
        {
            if (_IsGround && VRInput.RGrip)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }

    }
}
