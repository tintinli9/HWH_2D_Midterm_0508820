using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Header("消失")]
    public GameObject stone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "石頭")
        {
            stone.SetActive(false);
        }
    }
}
