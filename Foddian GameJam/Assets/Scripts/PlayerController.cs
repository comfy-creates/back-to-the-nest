using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 MaxVel;

    [SerializeField] float FlyForce;
    public Rigidbody2D _rb;

    Camera _cam;
    [HideInInspector] public bool _canJump = true;
    [SerializeField] LineRenderer Line;

    bool _firstJump;
    Transform _sr;

    StatsManager _stats;
    [SerializeField] Animator Anim;

    bool _firstFall;
    [SerializeField] AudioSource A, B;


    //[SerializeField] MMFeedbacks JumpFeedback, LandFeedback;
    [SerializeField] ParticleSystem FlySystem, JumpSystem, LandSystem;

    [SerializeField] UnityEvent Event;
    [SerializeField] Transform Arrow;

    private void Awake()
    {
        _stats = FindObjectOfType<StatsManager>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        Rotate();
        if (_rb.velocity.x < -0.1)
        {
            _sr.localScale = new Vector3(1, 1);
        }
        else if (_rb.velocity.x > 0.1)
        {
            _sr.localScale = new Vector3(-1, 1);
        }
        Vector2 __dif = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        Vector2 __mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && _canJump)
        {
            Arrow.gameObject.SetActive(true);
            Line.positionCount = 2;

            //Line.SetPosition(0, transform.position);
            //Line.SetPosition(1, __mPos);
        }

        if (Input.GetMouseButtonUp(0) && _canJump)
        {
            Arrow.gameObject.SetActive(false);
            Event.Invoke();
            A.Play();
            A.pitch = Random.Range(0.6f, 0.9f);
            JumpSystem.Play();
            FlySystem.Play();
            Anim.SetBool("Stretch", true);
            _firstFall = false;
            if (!_firstJump)
            {
                _stats.StartRun = true;
                _firstJump = true;
            }

            _stats.Jumps += 1;
            _canJump = false;
            __dif.Normalize();
            _rb.velocity = new Vector2(-__dif.x * 0.6f, -__dif.y) * FlyForce;

            //Line.positionCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;


        Event.Invoke();
        B.Play();
        B.pitch = Random.Range(0.6f, 0.9f);
        LandSystem.Play();
        Anim.SetBool("Stretch", false);
        FlySystem.Stop();

        if (_firstFall) return;

        Anim.SetTrigger("Squash");
        _firstFall = true;
    }

void Rotate()
{
        Vector3 targ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targ.z = 0f;
        Vector3 objectPos = Arrow.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        Arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
}
}
