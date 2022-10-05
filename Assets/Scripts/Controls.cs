using System;
using TMPro;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;
    public float ControlSpeedMultiplier;

    
    public int Length = 1;
    private int HpWall;
    private int HpFood;
    private float Qw;

    public GameObject Rthop;
    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private SnakeTail componentSnakeTail;
    public TextMesh TextMesh;
    public Game Game;
    private Snake componentSnake;
    


    private Vector2 touchLastPos;
    private float sidewaysSpeed;
    public Vector3 Velocity;

    private void Start()
    {
        mainCamera = Camera.main;
        componentSnake = GetComponent<Snake>();
        componentRigidbody = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<SnakeTail>();
        
        for (int i = 1; i < Length; i++) componentSnakeTail.AddCircle();
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += (delta.x * Sensitivity) * ControlSpeedMultiplier;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        Length = Mathf.Clamp(Length, 0, 20);

        if (Length == 0)
        {
            Game.OnPlayerDied();
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            componentSnakeTail.AddCircle();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            componentSnakeTail.RemoveCircle();
            
        }

        TextMesh.text = Length.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rthop = (collision.contacts[0].otherCollider.gameObject);
        
        if (collision.gameObject.tag == "BaseFood")
        {
            var Qwerty = Rthop.GetComponent<TextMesh>();
            HpFood = Convert.ToInt32(Qwerty.text);
            GetComponent<AudioSource>().Play();
            print(HpFood);

            var i = 0;
            Length += HpFood;
            while (i < HpFood)
            {
                i++;
                componentSnakeTail.AddCircle();
            }
            
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "SegmentOfWall")
        {
            var Qwerty = Rthop.GetComponent<NumberGenerator>();
            HpWall = Qwerty.HpSegment;
           
            
            print(HpWall);

            var i = 0;
            Length -= HpWall;
            while (i < HpWall)
            {
                i++;
                componentSnakeTail.RemoveCircle();
            }

            if (Length > 0)
            {
                GetComponent<ParticleSystem>().Play();
                Destroy(collision.gameObject);
            }
            
        }

    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed);

        sidewaysSpeed = 0;
    }
}
