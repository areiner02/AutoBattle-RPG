using System;

public class Archer : CharacterClass
{
    public Archer() 
    {
        name = "Archer";
        type = CharacterClassType.Archer;
        baseHealth = 160;
        baseDamage = 30;
        manaRecovery = 35;
        attackRange = 2;
        skill = new TripleShot();
        skillImplementation = TripleShotImplementation;
    }

    public void TripleShotImplementation(Character performer, Character target)
    {
        int fullDamage = 0;
        int[] damageArray = new int[3];
        for(int i = 0; i < damageArray.Length; i++)
        {
            int randomDamage = RandomHelper.GetRandomInt(0, skill.damage);
            damageArray[i] = randomDamage;
            fullDamage += randomDamage;
        }

        Console.ForegroundColor = performer.team.color;
        Console.WriteLine($"({performer.identifier}) {performer.name} performed a {skill.name} against ({target.identifier}) {target.name} dealing {damageArray[0]}, {damageArray[1]}, {damageArray[2]} damage and applying {skill.effect.name}");
        Console.ResetColor();

        target.TakeDamage(fullDamage);
        target.SubscribeStatusEffect(skill.effect.effectImplementation);
    }
}