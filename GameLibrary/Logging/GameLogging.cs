using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Logging
{
    public class GameLogging : IGameLogging
    {
        private TraceSource traceSource = new TraceSource("Game Library");
        private TextWriterTraceListener textWriter;

        public GameLogging()
        {
            traceSource.Switch = new SourceSwitch("GameLogging", "All");
            textWriter = new TextWriterTraceListener(new StreamWriter("logOutput.txt") { AutoFlush = true });
            traceSource.Listeners.Add(textWriter);
        }

        public void WriteErrorToText(string error)
        {
            throw new NotImplementedException();
        }

        public void WriteInformationToText(string writeToTxt)
        {
            traceSource.TraceEvent(TraceEventType.Information, 150, writeToTxt);
        }

        public void WriteWarningToText(string warning)
        {
            throw new NotImplementedException();
        }
    }
}
