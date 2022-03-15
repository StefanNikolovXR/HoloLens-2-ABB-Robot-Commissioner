using UnityEngine;

namespace HeathenEngineering.UX
{
    public class CommandDirector : MonoBehaviour
    {
        public CommandLibrary library;
        public BoolReference userOnly = new BoolReference(false);

        public CommandRaisedEvent evtCommandFound;

        /// <summary>
        /// Meant for use with InputFields on the OnEndEdit event.
        /// </summary>
        /// <remarks>
        /// This will search for a command in the provided input and if found will riase the <see cref="evtCommandFound"/> event with the required data
        /// </remarks>
        /// <param name="value"></param>
        public void ParseInput(string value)
        {
            var command = ParseCommand(value);
            if (command.isValid)
                evtCommandFound.Invoke(command);
        }

        /// <summary>
        /// Searches the input text for matching commands in the <see cref="library"/>.
        /// </summary>
        /// <param name="value">The string to search for commands</param>
        /// <returns>Returns a command data object whose <see cref="CommandData.isValid"/> value will indicate rather or not a command has been found. If a command has been found the other filds will be populated</returns>
        public CommandData ParseCommand(string value) => new CommandData(library, value, userOnly.Value);
    }
}
