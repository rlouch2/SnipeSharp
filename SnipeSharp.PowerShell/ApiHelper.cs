using System;
using SnipeSharp;
using SnipeSharp.Endpoints.ExtendedManagers;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.EndpointHelpers;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell
{
    internal static class ApiHelper
    {
        private static SnipeItApi _instance = null;
        public static SnipeItApi Instance
        {
            get
            {
                if(_instance == null)
                    throw new InvalidOperationException("Not connected to an instance.");
                else
                    return _instance;
            }

            set
            {
                if(value == null)
                    _instance = null;
                else if(_instance != null)
                    throw new InvalidOperationException("Cannot connect to an instance when already connected.");
                else
                    _instance = value;
            }
        }

        public static IRequestResponse CheckOutAsset(this AssetEndpointManager<Asset> manager, Asset asset, User user)
        {
            return manager.Checkout(new Asset {
                Id = asset.Id,
                CheckoutRequest = new AssetCheckoutRequest {
                    CheckoutToType = "user",
                    AssignedUser = user
                }
            });
        }

        public static IRequestResponse CheckOutAsset(this AssetEndpointManager<Asset> manager, Asset asset, Location location)
        {
            return manager.Checkout(new Asset {
                Id = asset.Id,
                CheckoutRequest = new AssetCheckoutRequest {
                    CheckoutToType = "location",
                    AssignedLocation = location
                }
            });
        }

        public static IRequestResponse CheckOutAsset(this AssetEndpointManager<Asset> manager, Asset asset, Asset assignedAsset)
        {
            return manager.Checkout(new Asset {
                Id = asset.Id,
                CheckoutRequest = new AssetCheckoutRequest {
                    CheckoutToType = "asset",
                    AssignedAsset = assignedAsset
                }
            });
        }
    }
}