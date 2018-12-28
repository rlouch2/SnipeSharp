using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT consumable.</para>
    /// <para type="description">The Find-Consumable cmdlet finds consumable objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Consumable</code>
    ///   <para>Finds all consumables.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Consumable "Frying Oil"</code>
    ///   <para>Finds consumables that match the search string "Frying Oil".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Consumable), SupportsPaging = true)]
    [OutputType(typeof(Consumable))]
    public class FindConsumable: FindObject<Consumable, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
