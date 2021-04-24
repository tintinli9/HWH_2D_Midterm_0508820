using UnityEngine;
using UnityEngine.UI;

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
    [Header("偵測範圍")]
    public float rangeAttack = 1.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;
    [Header("獲得音效")]
    public AudioClip soundGet;
    [Header("武力值")]
    public Text textPower;

    private int power = 24;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    private void Move()
    {
        float h = joystick.Horizontal;

        tra.Translate(h * speed * Time.deltaTime, 0, 0);

        ani.SetFloat("水平", h);
    }

    public void Attack()
    {
        aud.PlayOneShot(soundAttack, 0.3f);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up, 0, 1 << 8);

        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<Item>().DropProp();

        if (hit && hit.collider.tag == "武器")
        {
            Destroy(hit.collider.gameObject);
            aud.PlayOneShot(soundGet, 0.3f);
            power++ ;
            textPower.text = power + "%";
        }
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

    [Header("獲得金條音效")]
    public AudioClip soundEat;
    [Header("金幣數量")]
    public Text textCoin;

    private int coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "金幣")
        {
            aud.PlayOneShot(soundEat, 0.3f);
            coin++;
            Destroy(collision.gameObject);
            textCoin.text = "" + coin;
        }
    }
}

