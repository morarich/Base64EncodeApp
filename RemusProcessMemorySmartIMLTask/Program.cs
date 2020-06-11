using System;

namespace RemusProcessMemorySmartIMLTask
{
    /// <summary>
    /// This is class creates and instantiates the <see cref="DSTaskTemplate" />, <see cref="DSTaskTemplate" /> to process ReMUS xxxxx Test Output Files.
    /// </summary>
    /// <remarks>
    /// Author: Jason Hawthorne
    /// <para/>Created:  5/10/2015
    /// <para/>Modified By: 
    /// <para/>Date: 
    /// </remarks> 
    class Program
    {
        /// <summary>
        /// The main entry point for the task.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ProcessMemorySmartIMLTask agent = new ProcessMemorySmartIMLTask();
            agent.Run(args);
            agent.Dispose();
            if (agent != null) agent = null;

                    

            //string path = @"C:\Users\morarich\OneDrive - Hewlett Packard Enterprise\Rich\Documents\1-Rich\20190501 MemorySmartPPR\iml_log.json";
            //IMLParseDev test = new IMLParseDev(path);
            //test.run();

        }
    }
}
