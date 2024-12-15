using System;
using System.Collections.Generic;
using System.Text;

namespace FilerNS
{
    internal class Filer : IFiler
    {
        public string Load(string filename)
        {
            throw new Exception($"It's loaded! { filename }");
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            throw new Exception($"It's saved! { filename }");
        }
    }
}
