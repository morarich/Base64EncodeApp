using System;

namespace RemusProcessMemorySmatXMLTask
{
    /// <summary>
    /// This is class creates and instantiates the <see cref="ProcessMemorySmatXMLTask" />, <see cref="ProcessMemorySmatXMLTask" /> to process ReMUS xxxxx Test Output Files.
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
            ProcessMemorySmatXMLTask agent = new ProcessMemorySmatXMLTask();
            agent.Run(args);
        }
    }
}
