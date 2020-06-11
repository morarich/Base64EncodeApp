using System;

namespace RemusProcessMemorySmatXMLTask
{
    /// <summary>
    /// This class provides access to the command line options passed a ragumrnts from the console.
    /// </summary>
    /// <remarks>
    /// Author: Jason Hawthorne
    /// <para/>Created: 5/10/2015
    /// <para/>Modified By: 
    /// <para/>Date: 
    /// </remarks> 
    internal class CommandLineOptions
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineOptions"/> class.
        /// Options must have initilizer for all properties
        /// </summary>
        public CommandLineOptions()
        {
            ShowDetail = false;
            Interactive = false;
            ManualDateRangeProcessing = false;
            ManualFromDate = "";
            ManualToDate = "";
        }

        #endregion Constructors

        #region Class Methods

        /// <summary>
        /// Gets or sets the CMC URI.
        /// </summary>
        /// <value>
        /// The CMC URI.
        /// </value>
        public bool ShowDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CommandLineOptions"/> is interactive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if interactive; otherwise, <c>false</c>.
        /// </value>
        public bool Interactive { get; set; }

        public bool ManualDateRangeProcessing { get; set; }

        public String ManualFromDate { get; set; }

        public String ManualToDate { get; set; }

        #endregion Class Methods
    }
}
