
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    public CircleCollider2D coll;
    public float range;

    public List<GameObject> Enemys = new();

    private void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        coll.radius = range;
    }
    void Start()
    {
        InvokeRepeating("AutoAttackEnemies", 1f, 1f);
    }

    void Update()
    {

    }
    public void AutoAttackEnemies()
    {
        print("ATAQUE!");

        foreach (GameObject enemy in Enemys)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= range && enemy.GetComponent<Enemy>() != null)
                enemy.GetComponent<Enemy>().TakeDamage(this);
        }

    }

    private void OnDestroy()
    {
        Debug.Log("oh no me cancelaron");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
            Enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(Enemys.Find(collision.gameObject))
        Enemys.Remove(collision.gameObject);
    }

    public override void TakeDamage(BaseEntity damager)
    {
        // base.TakeDamage(damager);

        stats.TakeDamage((damager.Stats.Power) / 2);
    }
}
    
