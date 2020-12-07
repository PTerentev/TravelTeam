using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelTeam.Web.Infrastructure.Middlewares
{
    /// <summary>
    /// Problem field DTO.
    /// </summary>
    public class ProblemFieldDto
    {
        /// <summary>
        /// Field name.
        /// </summary>
        public string Field { get; }

        private readonly string[] messages;

        /// <summary>
        /// Field messages.
        /// </summary>
        public IReadOnlyList<string> Messages => messages;

        /// <summary>
        /// Problem field with no messages.
        /// </summary>
        public static ProblemFieldDto Empty => new ProblemFieldDto(string.Empty, new string[0]);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="field">Field name.</param>
        public ProblemFieldDto(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException(nameof(field));
            }
            this.Field = field;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="field">Field name.</param>
        /// <param name="messages">Messages.</param>
        public ProblemFieldDto(string field, IEnumerable<string> messages) : this(field)
        {
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            if (messages is string[] messagesAsArray)
            {
                this.messages = messagesAsArray;
            }
            else
            {
                this.messages = messages.ToArray();
            }
        }
    }
}
