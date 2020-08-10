namespace Application.Services.Game.Players.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerInputModel
    {
        public int KindId { get; set; }

        public int ClassId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}
