using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Bussines
{
    public class RdfHandler
    {
        private readonly RdfManager _rdfManager;

        public RdfHandler(string path)
        {
            _rdfManager=new RdfManager(path);
        }

        public List<String> GetProblemeDeMediu()
        {
            return _rdfManager.GetProblemeDeMediu();
        }

        public List<string> GetSectoareSiActivitati()
        {
            return _rdfManager.GetSectoareSiActivitati();
        }
    }
}
