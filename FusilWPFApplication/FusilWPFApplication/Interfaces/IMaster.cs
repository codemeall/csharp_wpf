using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FusilWPFApplication.Interfaces
{
    public interface IMaster
    {
       void Save();
       void Clear();
       void Update();
       void Delete();
       void Get();       
    }
}
