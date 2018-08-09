using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Category.</para>
    /// <para type="description">The Remove-Category cmdlet removes one or more Category objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
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
    /// <para type="link">Find-Category</para>
    [Cmdlet(VerbsCommon.Remove, nameof(Category),
        DefaultParameterSetName = nameof(RemoveObject<Category>.ParameterSets.ByName),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Category>))]
    public sealed class RemoveCategory: RemoveObject<Category>
    {
    }
}
