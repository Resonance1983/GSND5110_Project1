using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisWall : MonoBehaviour
{
    public enum WallType
    {
        WallPiece,
        Wall,
    }

    public WallType wallType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wallType == WallType.WallPiece)
        {
            PlayerController p = collision.GetComponent<PlayerController>();

            if (p != null)
            {
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Vector2 c = collision.ClosestPoint(transform.position);
                AddPlayerForce(p, c);
            }

            TetrisWall t = collision.GetComponent<TetrisWall>();

            if (t != null)
            {
                if (t.wallType == WallType.Wall)
                {
                    transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();

        if (p != null)
        {
            Vector2 c = collision.ClosestPoint(transform.position);
            AddPlayerForce(p, c);
        }
    }

    private void AddPlayerForce(PlayerController p ,Vector2 c)
    {
        Vector2 direction = new Vector2(transform.position.x, 0) - new Vector2(c.x, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 0.5f, ForceMode2D.Impulse);
    }
}
