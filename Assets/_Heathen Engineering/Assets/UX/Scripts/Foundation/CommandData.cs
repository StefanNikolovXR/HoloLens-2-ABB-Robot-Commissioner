using HeathenEngineering.Events;

using System;

namespace HeathenEngineering.UX
{
    [Serializable]
    public class CommandData
    {
        /// <summary>
        /// Indicates the command is valid
        /// </summary>
        public bool isValid;
        /// <summary>
        /// The command matched
        /// </summary>
        public GameEvent command;
        /// <summary>
        /// The input text parsed for the command
        /// </summary>
        public string sourceText;
        /// <summary>
        /// The text that followed the located command
        /// </summary>
        public string arguments;

        public CommandData() { }

        public CommandData(CommandLibrary library, string command, bool userOnly)
        {
            if (library != null
                && library.TryParseCommand(command, userOnly, out GameEvent gameEvent, out string arguments))
            {
                isValid = true;
                this.command = gameEvent;
                sourceText = command;
                this.arguments = arguments;
            }
            else
            {
                isValid = false;
                this.command = null;
                sourceText = command;
                this.arguments = string.Empty;
            }
        }
    }
}
