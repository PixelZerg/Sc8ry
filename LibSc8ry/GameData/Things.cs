using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSc8ry.GameData
{
    public class Things
    {
        public Framework.Thing banana = new Framework.Thing();

        public void Load()
        {
            this.LoadDefault();
        }

        private void LoadDefault()
        {
            banana.Description = "A yellow food. Almost certainly not producing antimatter.";
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
