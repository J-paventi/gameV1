﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameV1
{
    internal class Swords
    {
        // Class members
        private int damageModifier;
        private int accuracyModifier;
        private float critChanceModifier;
        private float critDamageModifier;

        // Mutators and Accessors
        public int DamageModifier { get => damageModifier; set => damageModifier = value; }
        public int AccuracyModifier { get => accuracyModifier; set => accuracyModifier = value; }
        public float CritChanceModifier { get => critChanceModifier; set => critChanceModifier = value; }
        public float CritDamageModifier { get => critDamageModifier; set => critDamageModifier = value; }

        public Swords()
        {
            DamageModifier = 5;
            AccuracyModifier = 10;
            CritChanceModifier = 0.5f;
            CritDamageModifier = 2;
        }
    }
}
