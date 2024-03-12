using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class GameLogging
    {
        private TraceSource traceSource = new TraceSource("Game Library");
        private TextWriterTraceListener textWriter;

        public GameLogging()
        {
            traceSource.Switch = new SourceSwitch("GameLogging", "All");
            textWriter = new TextWriterTraceListener(new StreamWriter("logOutput.txt") { AutoFlush = true });
            traceSource.Listeners.Add(textWriter);
        }
        public void WriteInformationToText(string writeToTxt)
        {
            traceSource.TraceEvent(TraceEventType.Information, 150, writeToTxt);
        }
    }
}
