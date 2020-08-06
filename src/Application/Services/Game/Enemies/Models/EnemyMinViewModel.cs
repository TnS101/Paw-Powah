namespace Application.Services.Game.Enemies.Models
{
    using Domain.Entities.Game.Units;

    public class EnemyMinViewModel : Enemy
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
