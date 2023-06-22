public class IceChamber : CharacterSkill
{
    public IceChamber()
    {
        name = "Ice Chamber";
        damage = 20;
        effect = new Stun(2);
    }
}