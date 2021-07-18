using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrler : MonoBehaviour
{

    [SerializeField, Range(0, 100)]
    public float _speed;


    [SerializeField, Range(0, 100)]
    public float _jumpForce;

    public Rigidbody _rigidbody;

    public PlayerStatus _status;

    //Weapon _weapon1;
    //Weapon _weapon2;

    public AbilitySuper _ability;


    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<PlayerStatus>();
        _rigidbody = GetComponent<Rigidbody>();
        //デフォルトのアビリティはスピードアップ
        SpeedUPAbi speed = new SpeedUPAbi();
        _ability= gameObject.AddComponent<SpeedUPAbi>();
        _ability._player = this;
        _ability.ChangeAbility(speed);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_ability);


        if(_ability != null)
        {
            _ability.UseAbility();
        }
        
        PlayerMove();
    }

    public void PlayerMove()
    { 
        Vector3 velocity = new Vector3(OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x, 0, OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y);
        velocity = transform.TransformDirection(velocity);
        transform.localPosition += velocity*_speed * Time.fixedDeltaTime;

        if (VRInput.A)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AbilitySuper>())
        {

        }
    }


}
