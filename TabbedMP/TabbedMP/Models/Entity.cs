using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TabbedMP.Models
{
    public enum eTag
    {
        Player,
        NPC,
        Monster,
    }
    public class Entity
    {
        //Header Info
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Klass { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }
        //Attributes Info
        public int CON { get; set; }
        public int DEX { get; set; }
        public int STR { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        public int INTEL { get; set; }
        public int modCON { get; set; }
        public int modDEX { get; set; }
        public int modSTR { get; set; }
        public int modWIS { get; set; }
        public int modCHAR { get; set; }
        public int modINTEL { get; set; }
        public int HP_temp { get; set; }
        public int HP_max { get; set; }
        public int HP_curr { get; set; }
        public string HP_dice { get; set; }
        public int Speed { get; set; }
        public int Armor_class { get; set; }
        public int Proff_bonus { get; set; }
        //Foreign Keys
        [OneToMany]
        public List<Tests> ID_tests { get; set; }
        //public int ID_notes { get; set; }
        //public int ID_spells { get; set; }
        //public int ID_spellslots { get; set; }
        //public int ID_inv { get; set; }

        //Entity aggregation data
        public eTag Tag { get; set; }
        //public int ID_lifesave {get; set; }
    }

    public class Tests
    {
        [PrimaryKey, ForeignKey(typeof(Entity))]
        public int ID_entity { get; set; }
        public string Title { get; set; }
        public string Modifier { get; set; }
    }
}