using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class PlayerCtrler : MonoBehaviour
{

    [SerializeField, Range(0, 100)]
    public float _speed;


    [SerializeField]
    public float _jumpForce;

    public Rigidbody _rigidbody;

    public PlayerStatus _status;

    //Weapon _weapon1;
    //Weapon _weapon2;

    public Ability _ability;


    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<PlayerStatus>();
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

        _rigidbody.position += transform.rotation * (Quaternion.Euler(rotation) * velocity * _speed);

        if (!_ability._flyable)
        {
            if (VRInput.A)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            if(VRInput.APress)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }

}
