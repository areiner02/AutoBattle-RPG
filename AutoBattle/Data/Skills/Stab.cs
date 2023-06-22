public class Stab : CharacterSkill
{
    public Stab()
    {
        name = "Stab";
        damage = 35;
        effect = new Bleed(20, 4);
    }
}