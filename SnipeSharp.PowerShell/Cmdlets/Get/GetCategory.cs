using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT category.</summary>
    /// <remarks>The Get-Category cmdlet gets one or more category objects by name or by Snipe IT internal id number.</remarks>
    /// <remarks>Whatever identifier is used, both accept pipeline input.</remarks>
    /// <example>
    ///   <code>Get-Category 14</code>
    ///   <para>Retrieve an category by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Category Category4368</code>
    ///   <para>Retrieve an category explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Category</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindCategory" />
    [Cmdlet(VerbsCommon.Get, nameof(Category), DefaultParameterSetName = nameof(GetCategory.ParameterSets.All))]
    [OutputType(typeof(Category))]
    public class GetCategory: GetObject<Category, ObjectBinding<Category>>
    {
    }
}