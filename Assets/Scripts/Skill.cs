using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int Ttl
    {
        get => _ttl;
        set => _ttl = value;
    }
    public bool IsActiveSkill
    {
        get => _isActiveSkill;
        set => _isActiveSkill = value;
    }

    private string _name;
    private bool   _isActiveSkill = false;// check if current skill is active or passive
    private int    _ttl           = -1;   // short for "Time-to-live", the duration that the skill is gonna last in the character pocket

    public virtual void Activate()
    {
        Debug.Log("Parent is being called");
        throw new System.NotImplementedException();
    }
    public virtual void OnExpire()
    {
        Debug.Log("Parent is being called");
        throw new System.NotImplementedException();
    }
}
