using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MU.DataBase
{
    [Table("MuHelper")]
    public class MuHelperDto
    {
        [Key]
        public int CharacterId { get; set; }
        public int OptionFlag1 { get; set; }
        public int OptionFlag2 { get; set; }
        public int ItemPickFlag { get; set; }
        public int HuntingRange { get; set; }
        public int Distance { get; set; }
        public int AttackSkill1 { get; set; }
        public int AttackSecSkill1 { get; set; }
        public int AttackSecSkill2 { get; set; }
        public int AttackSecDelay1 { get; set; }
        public int AttackSecDelay2 { get; set; }
        public int BuffSkill1 { get; set; }
        public int BuffSkill2 { get; set; }
        public int BuffSkill3 { get; set; }
        public int TimeSpaceCasting { get; set; }
        public int PercentAutoPot { get; set; }
        public int PercentAutoHeal { get; set; }
        public int PercentAutoPartyHeal { get; set; }
        public int PercentDrainLife { get; set; }
        public string PickItemList { get; set; }
        public int BuffItem1 { get; set; }
        public int BuffItem2 { get; set; }
        public int BuffItem3 { get; set; }
    }
}
