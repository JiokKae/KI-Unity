using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController2 : MonoBehaviour
{
    Rigidbody _rigidbody;
    SphereCollider sphereCollider;
    Animation anim;

    public Camera _camera;

    public float jumpPower = 50f;
    public float maxJumpPower = 500f;
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
        if (Input.mousePosition.x > Screen.width / 2)
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        if (_rigidbody.velocity.y > 5)
		{
            anim.Play("03_jumpup");
        }
        else if(_rigidbody.velocity.y < -5)
		{
            anim.Play("04_jumpdown");
		}
		else
		{
            anim.Play("01_Idle");
        }

        if(_rigidbody.velocity.magnitude < 0.01f)
		{
            if (Input.GetMouseButton(0))
            {
                jumpPower += addJumpPower * Time.deltaTime;
                jumpPower = Mathf.Clamp(jumpPower, 0f, maxJumpPower);

                float scaleY = 1.0f - (jumpPower / maxJumpPower) * 0.6f;

                sphereCollider.radius = scaleY;

                transform.localScale = new Vector3(1f, scaleY, 1f);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if(Input.mousePosition.x > Screen.width / 2)
                    _rigidbody.AddForce(jumpPower / 2, jumpPower, 0f);
                else
                    _rigidbody.AddForce(-jumpPower / 2, jumpPower, 0f);
                jumpPower = 100f;
                transform.localScale = new Vector3(1f, 1f, 1f);

                sphereCollider.radius = 1f;
            }
        }
        
        if(transform.position.y < -10f)
		{
            SceneManager.LoadScene("210128/Scene");
		}
    }

	private void LateUpdate()
	{
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
