namespace DndMonsterStatsGenerator
{
    /// <summary>
    /// This class represent all the stats for a monster
    /// </summary>
    public class MonsterStats
    {
        /// <summary>
        /// Gets or sets the armor class of the monster
        /// </summary>
        public byte AC { get; set; }

        /// <summary>
        /// Gets or sets the hit points of the monster
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Gets or sets the attack bonus of the monster
        /// </summary>
        public byte Attack { get; set; }

        /// <summary>
        /// Gets or sets the damage budget for all the monster's attacks. Limited-­use (daily, recharge, or situational) attacks do 4x the damage budgeted. Multi-­target attacks do ½ the damage budgeted. Limited-­use multi-­target attacks do 2x. All other damage sources are 1 for 1, including at-­will and legendary single-­target attacks, auras, reactions, and variable-­length effects like Swallow. If a monster has several at-­will options (such as melee and ranged), the lower-­damage options are free
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the Difficulty Class of the monster’s abilities.   
        /// </summary>
        public byte DC { get; set; }

        /// <summary>
        /// Gets or sets the bonus to those saving throws that the monster would naturally be good at (for instance Strength and Constitution for a bruiser, Intelligence for a wizard). This number also works for the bonus to a monster’s trained skills.Bad saving throws/untrained skills may be any value less than this.
        /// </summary>
        public byte Save { get; set; }
    }
}
