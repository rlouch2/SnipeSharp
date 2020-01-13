namespace SnipeSharp.Serialization
{
    internal interface IPatchable
    {
        /// <summary>
        /// Destructively modifies all "isModified" fields on an instance
        /// to the provided state. For example, if an object is submitted
        /// with the "Put" method, all properties will be marked modified.
        /// Or, after deserialization, all properties will be marked
        /// unmodified.
        /// </summary>
        void SetAllModifiedState(bool isModified);
    }
}
