using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.ClientServices
{
    internal interface IClientServiceBase
    {
        public string BaseAddress { get; set; }
    }
}
