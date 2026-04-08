
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    protected int entityID;
    protected string entityName;
    protected string enetityDescription;

    protected BaseStats stats;

    private void Awake()
    {
        stats = new(10, 10, 10, 10, 10);
    }
    private void Start()
    {
        
    }
    public virtual void TakeDamage(BaseEntity damager)
    {
        stats.TakeDamage(damager.stats.Power);
    }

    public BaseStats Stats => stats;
}
