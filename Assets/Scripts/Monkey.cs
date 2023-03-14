using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField]
    private int health;
    private List<Skill> _powers;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize monkey attributes
        // Initialize all the neccessary variables
        _powers = new List<Skill>();
    }

    void OnDeath()
    {
        // Play Death Animation
        // invoke stuffs
    }

    IEnumerator AcquireSkill(Skill skill)
    {
        _powers.Add(skill);
        // if there is a ttl for the current skill, we'll set the expire time for it
        if (skill.Ttl != -1)
        {
            yield return new WaitForSeconds(skill.Ttl);
            _powers.Remove(skill);
        }
    }

    void UsePassivePower()
    {
        foreach (Skill power in _powers)
        {
            var p = power as PassiveSkill;// casting check for corrct use of the power
            if (p != null)
            {
                power.Activate();
            }
        }
    }

    // this function arg should be passed from the UI of where the player click
    void UseActivePower(Skill skill)
    {
        if (_powers.Contains(skill))
            skill.Activate();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
