using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT Category.</summary>
    /// <remarks>
    ///   <para>The Remove-Category cmdlet removes one or more Category objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Remove-Category 12</code>
    ///   <para>Removes a Category by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Category Category4368</code>
    ///   <para>Removes a Category explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Category</code>
    ///   <para>Removes the first 100 Category objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindCategory" />
    [Cmdlet(VerbsCommon.Remove, nameof(Category),
        DefaultParameterSetName = nameof(RemoveObject<Category, ObjectBinding<Category>>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Category>))]
    public sealed class RemoveCategory: RemoveObject<Category, ObjectBinding<Category>>
    {
    }
}
