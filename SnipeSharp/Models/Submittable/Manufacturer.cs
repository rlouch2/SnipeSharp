using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Manufacturer.
    /// Manufacturers create accessories, consumables, licenses, and models (models are associated with assets).
    /// </summary>
    [PathSegment("manufacturers")]
    public sealed class Manufacturer : CommonEndPointModel, IAvailableActions, IPatchable
    {
        /// <summary>Create a new Manufacturer object.</summary>
        public Manufacturer() { }

        /// <summary>Create a new Manufacturer object with the supplied ID, for use with updating.</summary>
        internal Manufacturer(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>Gets/sets the URL for the Manufacturer's website.</value>
        [Field("url")]
        [Patch(nameof(isUrlModified))]
        public Uri Url
        {
            get => url;
            set
            {
                isUrlModified = true;
                url = value;
            }
        }
        private bool isUrlModified = false;
        private Uri url;

        /// <value>Gets/sets the URL of the image for the Manufacturer.</value>
        [Field("image")]
        [Patch(nameof(isImageUriModified))]
        public Uri ImageUri
        {
            get => imageUri;
            set
            {
                isImageUriModified = true;
                imageUri = value;
            }
        }
        private bool isImageUriModified = false;
        private Uri imageUri;

        /// <value>Gets/sets the url of the manufacturer's support site.</value>
        [Field("support_url")]
        [Patch(nameof(isSupportUrlModified))]
        public Uri SupportUrl
        {
            get => supportUrl;
            set
            {
                isSupportUrlModified = true;
                supportUrl = value;
            }
        }
        private bool isSupportUrlModified = false;
        private Uri supportUrl;


        /// <value>Gets/sets the manufacturer's support phone number.</value>
        [Field("support_phone")]
        [Patch(nameof(isSupportPhoneNumberModified))]
        public string SupportPhoneNumber
        {
            get => supportPhoneNumber;
            set
            {
                isSupportPhoneNumberModified = true;
                supportPhoneNumber = value;
            }
        }
        private bool isSupportPhoneNumberModified = false;
        private string supportPhoneNumber;

        /// <value>Gets/sets the manufacturer's support email address.</value>
        [Field("support_email")]
        [Patch(nameof(isSupportEmailAddressModified))]
        public string SupportEmailAddress
        {
            get => supportEmailAddress;
            set
            {
                isSupportEmailAddressModified = true;
                supportEmailAddress = value;
            }
        }
        private bool isSupportEmailAddressModified = false;
        private string supportEmailAddress;

        /// <value>The number of assets produced by this manufacturer.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of licenses produced by this manufacturer.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>The number of consumables produced by this manufacturer.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>The number of accessories produced by this manufacturer.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets the date this manufacturer was deleted.</value>
        [Field(DeserializeAs = "deleted_at", Converter = DateTimeConverter)]
        public DateTime? DeletedAt { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isUrlModified = isModified;
            isImageUriModified = isModified;
            isSupportUrlModified = isModified;
            isSupportPhoneNumberModified = isModified;
            isSupportEmailAddressModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
