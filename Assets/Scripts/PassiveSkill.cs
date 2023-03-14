using UnityEngine;

public abstract class PassiveSkill : Skill
{
    // passive skills
    private float _triggerInterval;

    public override void Activate()
    {
        Debug.Log("Activate {} is called from" + GetType());
    }
    public override void OnExpire()
    {
    }
}
