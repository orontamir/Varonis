using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varonic.IO;

namespace Varonis_Exc
{
    class db:IAction
    {
        public string Action(string id)
        {
            var path = Varonic.DataBase.Commands.Instance.GetPathCommand(id);
            var score = Read.Instance.ReadJsonFromPath(path);
            return score.ToString();
        }
    }
}
