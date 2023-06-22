public class CharacterClass
{
    public string name;
    public CharacterClassType type;
    public int baseHealth;
    public int manaRecovery;
    public int baseDamage;
    public int attackRange;
    public CharacterSkill skill;
    public delegate void skillDelegate(Character performer, Character target);
    public skillDelegate skillImplementation;
}