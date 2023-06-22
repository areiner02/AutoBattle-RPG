public class Heal : CharacterSkill
{
    public Heal()
    {
        name = "Heal";
        damage = 35;
        effect = new HealingAura(5);
    }
}