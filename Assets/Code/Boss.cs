using UnityEngine;
using System.Collections;
using System;

public class Boss : MonoBehaviour, ITakeDamage 
{

    public Transform[] spots;
    public float speed;
    public float bossHealth = 100;
    public float projectileSpeed;
    private bool vulnerable;
    private bool dead;

    public Transform[] shootSpots;
    public GameObject projectile;

    GameObject Player;
    Vector3 playerPosition;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("boss");
	
	}
	
	// Update is called once per frame
	void Update () {

        if (bossHealth <= 0 && !dead)
        {
            dead = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
            StopCoroutine("boss");
        }
	
	}

    IEnumerator boss()
    {
        while (true)
        {
            //first attack

            while (transform.position.x != spots[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), speed);

                yield return null;
            }

            // transform.localScale = new Vector2(-1,1);

            yield return new WaitForSeconds(1f);

            int i = 0;
            while (i < 6)
            {
                GameObject bullet = (GameObject)Instantiate(projectile, shootSpots[UnityEngine.Random.Range(0, 2)].position, Quaternion.identity);
                //bullet.GetComponent<Rigidbody2D>().velocity = -Vector2.right * projectileSpeed;
                i++;
                yield return new WaitForSeconds(1f);
            }

            //second attack
            while (transform.position != spots[2].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[2].position, speed);
                yield return null;
            }

            playerPosition = Player.transform.position;

            yield return new WaitForSeconds(1f);

            while (transform.position.x != playerPosition.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.x, playerPosition.y), speed);

                yield return null;
            }

            this.tag = "Untagged";
            vulnerable = true;
            yield return new WaitForSeconds(4f);
            this.tag = "Deadly";
            vulnerable = false;

            //third attack
            //Transform temp;
            //if (transform.position.x > Player.transform.position.x)
            //    temp = spots[1];
            //else
            //    temp = spots[0];

            //while (transform.position.x != temp.position.x)
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, temp.position.y), speed);
            //    yield return null;
            //}

        }
    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        if (vulnerable)
        {
            bossHealth -= 50;
            vulnerable = false;
        }
    }
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.collider.tag == "Player")
    //    {
    //        Console.WriteLine("asd");
    //    }
    //}
}
