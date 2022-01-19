using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MastersPeon.Models
{
    public enum eTag
    {
        Player,
        NPC,
        Monster,
    }

    public enum attTypes
    {
        CON,
        DEX,
        STR,
        WIS,
        INT,
        CHA,
    }
    public class eBase
    {
        public string Text { get; set; }
        public string Description { get; set; }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Header Info
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Klass { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }
        private int _val;
        //Attributes Info
        public int CON { get; set; }
        public int DEX { get; set; }
        public int STR { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        public int INTEL { get; set; }
        public int modCON
        {
            get => attconvo(CON, false, null);
        }
        public int modDEX
        {
            get => attconvo(DEX, false, null);
        }
        public int modSTR
        {
            get => attconvo(STR, false, null);
        }
        public int modWIS
        {
            get => attconvo(WIS, false, null);
        }
        public int modCHAR
        {
            get => attconvo(CHA, false, null);
        }
        public int modINTEL
        {
            get => attconvo(INTEL, false, null);
        }
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
        //public int ID_lifesave {get; set; }

        //Entity aggregation data
        public eTag Tag { get; set; }

        private int attconvo(int att, bool mod, object T)
        {
            double val;
            if (T == null)
            {
                val = (att - 10) / 2;
                return Convert.ToInt32(Math.Floor(val));
            }
            else
            {
                attTypes sw = (attTypes)T;
                switch (sw)
                {
                    case attTypes.CON:
                        val = CON;
                        break;
                    case attTypes.DEX:
                        val = DEX;
                        break;
                    case attTypes.STR:
                        val = STR;
                        break;
                    case attTypes.CHA:
                        val = CHA;
                        break;
                    case attTypes.INT:
                        val = INTEL;
                        break;
                    case attTypes.WIS:
                        val = WIS;
                        break;
                    default: val = 0;
                        break;
                }
                if (mod)
                {
                    return attconvo(Convert.ToInt32(val), false, null);
                }
                else
                {
                    return Convert.ToInt32(val);
                }
            }
        }
    }

    public class Tests
    {
        [PrimaryKey, ForeignKey(typeof(eBase))]
        public int ID_entity { get; set; }
        public string Title { get; set; }
        public attTypes Modifier { get; set; }
    }
}