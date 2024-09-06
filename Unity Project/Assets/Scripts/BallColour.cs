using UnityEngine;

public class BallColour : ScriptAdder<BallMovement>
{
    SpriteRenderer spriteRenderer = null;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Awake();
    }

    private void Update()
    {
        if (spriteRenderer.color == Color.white)
        {
            return;
        }

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "PlayerLeft":
                spriteRenderer.color = Color.green;
                break;
            case "PlayerRight":
                spriteRenderer.color = Color.magenta;
                break;
        }
    }
}
