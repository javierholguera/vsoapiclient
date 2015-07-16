using System;

namespace VsoApi.Contracts.Models
{
    /// <summary>
    /// Represents a property that can be serialized back and forth, but is set by VSO internally.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ReadOnlyAttribute : Attribute
    {
        public ReadOnlyAttribute() : this(false)
        {
        }

        public ReadOnlyAttribute(bool canOverride)
        {
            CanOverride = canOverride;
        }

        /// <summary>
        /// Gets or sets a value indicating whether even if the field is considered ReadOnly by VSO API,
        /// it is still allowed to sent it.
        /// </summary>
        public bool CanOverride { get; private set; }
    }
}