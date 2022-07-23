using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private SimpleTouchPad touchPad;
    [SerializeField] private List<Vector2> clickSequence;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance = .1f;
    [SerializeField] private Animator animator;
    [SerializeField] private UISampleScene uISampleScene;
    private bool controlBlock;

    private void Start()
    {
        clickSequence = new List<Vector2>();
        controlBlock = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Click();
        }
        if (clickSequence.Count > 0 && !controlBlock)
        {
            moveSpeed = 5;
        }
        else
        {
            moveSpeed = 0;
        }
        if(clickSequence.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, clickSequence[0], Time.deltaTime * moveSpeed);
            var distanceSqure = new Vector2(transform.position.x - clickSequence[0].x, transform.position.y - clickSequence[0].y).sqrMagnitude;
            if(distanceSqure < maxDistance * maxDistance)
            {
                clickSequence.RemoveAt(0);
            }
        }

    }

    private void Click()
    {
        clickSequence.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }


    public void OnDrawGizmos()
    {
        Vector2[] points = new Vector2[clickSequence.Count];
        clickSequence.CopyTo(points);
        if(clickSequence.Count > 0)
        {
            Gizmos.DrawLine(transform.position, clickSequence[0]);
            for(int i = 1; i < points.Length; i++)
            {
                if(points.Length > 1)
                {
                    Gizmos.DrawLine(points[i-1], points[i]);
                }

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Spike"))
        {
            animator.SetTrigger("Burst");
            controlBlock = true;
        }
    }

    public void Loss()
    {
        uISampleScene.Loss();
    }
}
