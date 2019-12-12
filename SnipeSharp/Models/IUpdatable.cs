namespace SnipeSharp.Models
{
    /// <summary>
    /// Allows modifying a lightweight copy of an object with only the
    /// essential fields, for use when patching existing objects.
    /// </summary>
    public interface IUpdatable<T>
    {
        /// <summary>
        /// Retrieve a copy of the object with only the essential fields set.
        /// </summary>
        T CloneForUpdate();

        /// <summary>
        /// Creates an "update" object for submitting, with the essential fields
        /// of the current object, and the value fields from the provided object.
        /// </summary>
        T WithValuesFrom(T other);
    }
}
