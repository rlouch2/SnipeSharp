using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT consumable.</summary>
    /// <remarks>The Find-Consumable cmdlet finds consumable objects by filter.</remarks>
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
    public class FindConsumable: FindObject<Consumable>
    {
    }
}
