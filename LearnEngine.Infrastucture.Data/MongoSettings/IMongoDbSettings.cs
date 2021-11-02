using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.Settings.MongoSettings
{
    public interface IMongoDbSettings
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
    }
}
