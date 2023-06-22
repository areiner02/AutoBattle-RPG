public class TripleShot : CharacterSkill
{
    public TripleShot()
    {
        name = "Triple Shot";
        damage = 18;
        effect = new Bleed(12, 3);
    }
}