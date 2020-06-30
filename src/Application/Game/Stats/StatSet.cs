namespace Application.Game.Stats
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Units;

    public class StatSet
    {
        public Player PlayerStatSet(Class fightingClass, Player player, Kind kind)
        {
            player.ClassId = fightingClass.Id;
            player.MaxHP = fightingClass.MaxHP;
            player.CurrentHP = fightingClass.MaxHP;
            player.HealthRegen = fightingClass.HealthRegen;
            player.MaxMana = fightingClass.MaxMana;
            player.CurrentMana = fightingClass.MaxMana;
            player.ManaRegen = fightingClass.ManaRegen;
            player.AttackPower = fightingClass.AttackPower;
            player.MagicPower = fightingClass.MagicPower;
            player.Armor = fightingClass.Armor;
            player.Resistance = fightingClass.Resistance;
            player.CritChance = fightingClass.CritChance;
            player.ImagePath = fightingClass.ImagePath;

            return player;
        }

        public GeneratedEnemy EnemyStatSet(Enemy baseEnemy, int refLevel)
        {
            var enemy = new GeneratedEnemy();

            int step = this.StepCalculation(refLevel);

            enemy.Name = baseEnemy.Name;
            enemy.MaxHP = baseEnemy.MaxHP + (step * 20);
            enemy.HealthRegen = baseEnemy.HealthRegen + (step * 1);
            enemy.MaxMana = baseEnemy.MaxMana + (step * 15);
            enemy.ManaRegen = baseEnemy.ManaRegen + (step * 1.2);
            enemy.AttackPower = baseEnemy.AttackPower + (step * 2.6);
            enemy.MagicPower = baseEnemy.MagicPower + (step * 3);
            enemy.Armor = baseEnemy.Armor + (step * 1.3);
            enemy.Resistance = baseEnemy.Resistance + (step * 1);
            enemy.CritChance = baseEnemy.CritChance + (enemy.Level * 0.02);
            enemy.ImagePath = baseEnemy.ImagePath;

            return enemy;
        }

        private int StepCalculation(int monsterLevel)
        {
            if (monsterLevel == 4)
            {
                return 6;
            }
            else if (monsterLevel == 5)
            {
                return 6 + monsterLevel - 1;
            }
            else if (monsterLevel > 5)
            {
                int repeatSteps = monsterLevel - 1;
                int step = 0;

                for (int i = 1; i <= repeatSteps; i++)
                {
                    step += monsterLevel - i;
                }

                return step;
            }
            else
            {
                return monsterLevel;
            }
        }
    }
}
