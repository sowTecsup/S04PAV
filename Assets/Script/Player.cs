using UnityEngine;

public class Player : MonoBehaviour
{
    public BaseStats stats;

    public float range;


    private void Awake()
    {
        stats = new BaseStats(10, 10, 5, 1, 20);//->A
        print(stats.Power);


        
    }
    void Start()
    {
        InvokeRepeating("AutoAttackEnemies",1f, 1f);
    }

    void Update()
    {   
        
    }



    public void AutoAttackEnemies()
    {
        print("ATAQUE!");

        GameObject[] allEnemies =  GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in allEnemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);

            if(distance <= range)
                enemy.GetComponent<Enemy>().TakeDamage(this);
        }

    }

    private void OnDestroy()
    {
        Debug.Log("oh no me cancelaron");
    }
}
