using System;
using System.Management.Automation;
using System.Reflection;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell
{
    internal sealed class PSAssetCustomFieldProperty : PSCodeProperty
    {
        public PSAssetCustomFieldProperty(string name, string propertyName)
            : base(name, GetAssetMethodInfo)
        {
            PropertyName = propertyName;
        }
        private string PropertyName;

        #region GetterMethod
        private static MethodInfo _methodInfo = null;
        private static MethodInfo GetAssetMethodInfo
        {
            get
            {
                if(null != _methodInfo)
                    return _methodInfo;
                _methodInfo = typeof(PSAssetCustomFieldProperty).GetMethod(nameof(GetAsset));
                return _methodInfo;
            }
        }
        public static Asset GetAsset(PSObject obj)
            => (Asset)obj.BaseObject;
        #endregion

        public override PSMemberInfo Copy()
        {
            var clone = new PSAssetCustomFieldProperty(Name, PropertyName);
            var method = typeof(PSMemberInfo).GetMethod("CloneBaseProperties", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(this, new [] { clone });
            return clone;
        }

        // necessary things
        public override bool IsGettable => true;
        public override bool IsSettable => true;
        public override string TypeNameOfValue => typeof(String).FullName;

        public override object Value
        {
            get
            {
                var asset = (Asset)base.Value;
                return asset.CustomFields.Friendly[PropertyName];
            }
            set
            {
                var asset = (Asset)base.Value;
                asset.CustomFields.Friendly[PropertyName] = value?.ToString();
            }
        }
    }
}
