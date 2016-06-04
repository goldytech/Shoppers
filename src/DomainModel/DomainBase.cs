namespace DomainModel
{
    using System;

    /// <summary>
    /// The Base Entity object.
    /// </summary>
    public abstract class DomainBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the time stamp for concurrency checks.
        /// </summary>
        public byte[] TimeStamp { get; set; }

        // similar add the properties of audit trial like (LastModifiedData,ModifiedBy etc.)

    }
}