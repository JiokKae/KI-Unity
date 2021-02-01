using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController2 : MonoBehaviour
{
    public enum State
	{
        JUMP,
        RUNNING,
        END
	};

    State state;
    Rigidbody _rigidbody;
    SphereCollider sphereCollider;
    Animation anim;

    public float jumpPower = 50f;
    public float maxJumpPower = 500f;
    public Camera cam;
    float camPitch;
    float addJumpPower;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        anim = GetComponent<Animation>();
        addJumpPower = maxJumpPower / 1.5f;
        anim.Play("01_Idle");
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            cam.gameObject.SetActive(!cam.gameObject.activeSelf);

        switch(state)
		{
            case State.JUMP:
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }

                if (Input.GetAxis("Mouse Y") > 0)
                    camPitch += 90f * Time.deltaTime;
                else if (Input.GetAxis("Mouse Y") < 0)
                    camPitch -= 90f * Time.deltaTime;
                camPitch = Mathf.Clamp(camPitch, -90, 90);
                if (_rigidbody.velocity.y > 5)
                {
                    anim.Play("03_jumpup");
                }
                else if (_rigidbody.velocity.y < -5)
                {
                    anim.Play("04_jumpdown");
                }
                else
                {
                    anim.Play("01_Idle");
                }

                if (_rigidbody.velocity.magnitude < 0.01f)
                {
                    if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                    {
                        jumpPower += addJumpPower * Time.deltaTime;
                        jumpPower = Mathf.Clamp(jumpPower, 0f, maxJumpPower);

                        float scaleY = 1.0f - (jumpPower / maxJumpPower) * 0.6f;

                        sphereCollider.radius = scaleY;

                        transform.localScale = new Vector3(1f, scaleY, 1f);
                    }
                    else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
                    {
                        if (Input.mousePosition.x > Screen.width / 2)
                            _rigidbody.AddForce(jumpPower / 2, jumpPower, 0f);
                        else
                            _rigidbody.AddForce(-jumpPower / 2, jumpPower, 0f);
                        jumpPower = 100f;
                        transform.localScale = new Vector3(1f, 1f, 1f);

                        sphereCollider.radius = 1f;
                    }
                }

                if (transform.position.x > 20f)
                {
                    state = State.RUNNING;
                    jumpPower = 300f;
                    sphereCollider.material = null;
                    
                }
                break;

            case State.RUNNING:

                if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
                {
                    if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                    {
                        jumpPower += addJumpPower * Time.deltaTime;
                        jumpPower = Mathf.Clamp(jumpPower, 0f, maxJumpPower);

                        float scaleY = 1.0f - (jumpPower / maxJumpPower) * 0.6f;

                        sphereCollider.radius = scaleY;

                        transform.localScale = new Vector3(1f, scaleY, 1f);
                    }
                    else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
                    {
                        _rigidbody.AddForce(0, jumpPower, 0f);

                        jumpPower = 300f;
                        transform.localScale = new Vector3(1f, 1f, 1f);

                        sphereCollider.radius = 1f;
                    }
                    _rigidbody.transform.position = _rigidbody.transform.position + new Vector3(8f, 0f, 0f) * Time.deltaTime;
                    anim.Play("12_walk");
                }
				else
				{
                    if (_rigidbody.velocity.y > 5)
                    {
                        anim.Play("03_jumpup");
                    }
                    else if (_rigidbody.velocity.y < -5)
                    {
                        anim.Play("04_jumpdown");
                    }
                    else
                    {
                        anim.Play("01_Idle");
                    }
                    _rigidbody.transform.position = _rigidbody.transform.position + new Vector3(6f, 0f, 0f) * Time.deltaTime;
                }

                break;
		}
       
        // 떨어지면 재시작
        if(transform.position.y < -10f)
		{
            SceneManager.LoadScene("210128/Scene");
		}


    }

	private void LateUpdate()
    {
        if (Input.mousePosition.x > Screen.width / 2)
        {
            cam.transform.position = transform.position + new Vector3(0.5f, 1.5f, 0.0f);
            cam.transform.rotation = Quaternion.Euler(-camPitch, 90f, 0f);
        }
        else
        {
            cam.transform.position = transform.position + new Vector3(-0.5f, 1.5f, 0.0f);
            cam.transform.rotation = Quaternion.Euler(-camPitch, 270f, 0f);
        }
	}
}
