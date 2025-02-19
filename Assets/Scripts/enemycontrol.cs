using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontrol : MonoBehaviour
{
    GameObject scorecount;

    public GameObject explosionGO;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;

        scorecount = GameObject.FindGameObjectWithTag("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShip") || (col.tag == "PlayerBullet"))
        {
            PlayExplosion();

            scorecount.GetComponent<gamescore>().Score += 150;

            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGO);
        explosion.transform.position = transform.position;
    }
}
