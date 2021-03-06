using System;

namespace JPProject.Admin.Application.ViewModels
{
    public class PersistedGrantViewModel
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets the subject identifier.
        /// </summary>
        /// <value>
        /// The subject identifier.
        /// </value>
        public string SubjectId { get; set; }

        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>
        /// The creation time.
        /// </value>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        /// <value>
        /// The expiration.
        /// </value>
        public DateTime? Expiration { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public string Data { get; set; }
        public PersistedGrantViewModel() { }
        public PersistedGrantViewModel(string key, string type, string subjectId, string clientId, DateTime creationTime, DateTime? expiration, string data)
        {
            Key = key;
            Type = type;
            SubjectId = subjectId;
            ClientId = clientId;
            CreationTime = creationTime;
            Expiration = expiration;
            Data = data;
        }

        public void UpdateUserInfo(string email)
        {
            Email = email;
        }
    }
}
