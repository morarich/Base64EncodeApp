using System.Collections.Generic;

namespace RemusProcessMemorySmatXMLTask
{
    /// <summary>
    /// This class provides the <see cref="TaskConfig" />, <see cref="TaskConfig" /> which contains the configuration for this Tasks process.
    /// </summary>
    /// <remarks>
    /// Author: Jason Hawthorne
    /// <para/>Created:  5/10/2015
    /// <para/>Modified By: 
    /// <para/>Date: 
    /// </remarks> 
    public sealed class TaskConfig
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskConfig"/> class.
        /// </summary>
        public TaskConfig()
        {

        }

        #endregion Constructors

        #region Class Methods

        public string SourceHost { get; set; }

        public string SourceUserName { get; set; }

        public string SourcePassword { get; set; }

        public int SourcePort { get; set; }

        public string SourceWorkDirectory { get; set; }

        public string SqlConnectionString { get; set; }

        public bool IsProduction { get; set; }

        public int TimeOffset { get; set; }

        public string TestOutputFileName { get; set; }

        public string EventLogPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [log information].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log information]; otherwise, <c>false</c>.
        /// </value>
        public bool LogInformation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [log warnings].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log warnings]; otherwise, <c>false</c>.
        /// </value>
        public bool LogWarnings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [log errors].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log errors]; otherwise, <c>false</c>.
        /// </value>
        public bool LogErrors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [log failure audits].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log failure audits]; otherwise, <c>false</c>.
        /// </value>
        public bool LogFailureAudits { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [log success audits].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log success audits]; otherwise, <c>false</c>.
        /// </value>
        public bool LogSuccessAudits { get; set; }

        /// <summary>
        /// Gets or sets the maximum file to process.
        /// </summary>
        /// <value>
        /// The maximum file to process.
        /// </value>
        public int MaxFilesToProcess { get; set; }

        /// <summary>
        /// Gets or sets the mail from.
        /// </summary>
        /// <value>
        /// The mail from.
        /// </value>
        public string MailFrom { get; set; }

        /// <summary>
        /// Gets or sets the mail to.
        /// </summary>
        /// <value>
        /// The mail to.
        /// </value>
        public string MailTo { get; set; }

        /// <summary>
        /// Gets or sets the mail cc.
        /// </summary>
        /// <value>
        /// The mail cc.
        /// </value>
        public string MailCc { get; set; }

        /// <summary>
        /// Gets or sets the mail server.
        /// </summary>
        /// <value>
        /// The mail server.
        /// </value>
        public string MailServer { get; set; }

        /// <summary>
        /// Gets or sets the mail server port.
        /// </summary>
        /// <value>
        /// The mail server port.
        /// </value>
        public int MailServerPort { get; set; }

        #endregion Class Methods
    }
}
