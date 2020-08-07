namespace Application.Game.Stats
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Units;

    public class StatSet
    {
        public Player PlayerStatSet(BattleClass battleClass, Player player, string kindStatType, double kindStatAmount)
        {
            player.MaxHP = battleClass.MaxHP;
            player.CurrentHP = battleClass.MaxHP;
            player.HealthRegen = battleClass.HealthRegen;
            player.MaxMana = battleClass.MaxMana;
            player.CurrentMana = battleClass.MaxMana;
            player.ManaRegen = battleClass.ManaRegen;
            player.AttackPower = battleClass.AttackPower;
            player.MagicPower = battleClass.MagicPower;
            player.Armor = battleClass.Armor;
            player.Resistance = battleClass.Resistance;
            player.CritChance = battleClass.CritChance;
            player.ImagePath = battleClass.ImagePath;

            new StatProcessor().Execute(player, kindStatType, kindStatAmount, "+");

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
            enemy.Gold = (int)this.EnemyCombinedStats(enemy) / 20;
            enemy.XPReward = (int)this.EnemyCombinedStats(enemy) / 10;
            return enemy;
        }

        private double EnemyCombinedStats(GeneratedEnemy enemy)
        {
            return enemy.MaxHP + enemy.MaxMana + enemy.AttackPower + enemy.MagicPower
                + enemy.Armor + enemy.Resistance + enemy.HealthRegen + enemy.ManaRegen + enemy.CritChance;
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
