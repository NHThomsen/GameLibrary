using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IGameLogging
    {
        void WriteInformationToText(string information);
        void WriteWarningToText(string warning);
        void WriteErrorToText(string error);
    }
}
