public class Stats
{
    public float health;
    public float maxHealth;

    public int level;
    public float attack;
    public float deffense;
    public float spirit;
    public float speed;

    public Stats(int _level, float _maxhealth, float _attack, float _deffense, float _spirit, float _speed)
    {
        this.level = _level;

        this.maxHealth = _maxhealth;
        this.health = _maxhealth;

        this.attack = _attack;
        this.deffense = _deffense;
        this.spirit = _spirit;
        this.speed = _speed;
    }

    public Stats Clone()
    {
        return new Stats(this.level, this.maxHealth, this.attack, this.deffense, this.spirit, this.speed);
    }
}
