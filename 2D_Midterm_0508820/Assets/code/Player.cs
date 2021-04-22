using UnityEngine;

public class Player : MonoBehaviour
{
    public int lv = 1;
    [Range(0,15)]
    public float speed = 10.5f;
    public bool isDEAD = false;
    public string cNAME = "主角";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;

    private void Move()
    {
        float h = joystick.Horizontal;

        tra.Translate(h * speed * Time.deltaTime, 0, 0);

        ani.SetFloat("水平", h);
    }

    private void Attack()
    {

    }

    private void Hit()
    {

    }

    private void Dead()
    {

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }
}

