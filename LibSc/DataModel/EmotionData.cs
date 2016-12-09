using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc.DataModel
{
    public class EmotionData :IData
    {
        public int Happiness = 0;
        public int Anger = 0;
        public int Suicidalness = 0;

        public byte[] GetBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
            {
                bw.Write(this.Happiness);
                bw.Write(this.Anger);
                bw.Write(this.Suicidalness);
                return Utils.AddSectionHeader(ms.ToArray(), DataType.EmotionData);
            }
        }

        public void ParseBytes(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
            {
                this.Happiness = br.ReadInt32();
                this.Anger = br.ReadInt32();
                this.Suicidalness = br.ReadInt32();
            }
        }
    }
}
