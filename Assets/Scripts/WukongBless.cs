/// <summary>
/// Turn our current monkey to have Wukong appearance and power
/// Able to travel fast (getting extra points), preserve energy and have all the available bananas in the map (through cloning jutsu)
/// </summary>
public sealed class WukongBless : PassiveSkill
{
    private void Start()
    {
        this.Ttl = 4;
        this.IsActiveSkill = false;
    }
}