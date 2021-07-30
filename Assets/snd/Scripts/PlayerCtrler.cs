using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class PlayerCtrler : MonoBehaviour
{

    [SerializeField]
    public float _speed;

    public float _MaxSpeed;


    [SerializeField]
    public float _jumpForce;



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



        //スピードアップアビリティを使ってない時 速度制限
        if (!Ability._SpeedUPEnable && !_ability._IsUsing )
        {
            if (_rigidbody.velocity.magnitude < _MaxSpeed)
                _rigidbody.AddForce(transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed * Time.deltaTime), ForceMode.Acceleration);
        }
        else
        {
            _rigidbody.AddForce(transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed * Time.deltaTime), ForceMode.Acceleration);
        }


        // _rigidbody.position += ;

        if (!_ability._flyable && VRInput.RGrip)
        {       //ハイパー雑な着地判定
            if (Physics.Raycast(transform.position - new Vector3(0, 1f, 0), Vector3.down, _GroundThre))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }

        }

    }

}
