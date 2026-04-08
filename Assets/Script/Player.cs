
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BaseStats stats;

    public float range;

    public CircleCollider2D coll;

    public List<GameObject> Enemys =new();

    private void Awake()
    {
        stats = new BaseStats(10, 10, 5, 1, 20);//->A
        print(stats.Power);

        coll = GetComponent<CircleCollider2D>();
        coll.radius = range;
    }
    void Start()
    {


        //InvokeRepeating("AutoAttackEnemies", 1f, 1f);
    }

    void Update()
    {

    }
    public void AutoAttackEnemies()
    {
        /*print("ATAQUE!");

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in allEnemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);

            if (distance <= range)
                enemy.GetComponent<Enemy>().TakeDamage(this);
        }
        */
    }

    private void OnDestroy()
    {
        Debug.Log("oh no me cancelaron");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemys.Remove(collision.gameObject);
    }
}
    
