﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class CharBase : IData
    {
        public bool IsDead = false;
        public Utils.CharacterType CharacterType = 0;
        /// <summary>
        /// The first 2 slots is for Weapon and Gear and the rest is for item storage
        /// </summary>
        public Int32[] Slots = new Int32[12];

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.IsDead);
                bw.Write((ushort)this.CharacterType);
                for (int i = 0; i < 12; i++)
                {
                    bw.Write((Int32)Slots[i]);
                }
                return Utils.AddSectionHeader(ms.ToArray(), DataType.CharBase);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.IsDead = br.ReadBoolean();
                this.CharacterType = (Utils.CharacterType)br.ReadUInt16();
                for (int i = 0; i < 12; i++)
                {
                    Slots[i] = br.ReadInt32();
                }
            }
        }
    }
}
