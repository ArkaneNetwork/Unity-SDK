using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VenlySDK.Utils;

namespace VenlySDK.Models.Shared
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyEnvironment
    {
        [EnumMember(Value = "STAGING")] staging,
        [EnumMember(Value = "PRODUCTION")] production
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyBackendProvider
    {
        [EnumMember(Value = "DEV_MODE")] DevMode,
        [EnumMember(Value = "CUSTOM")] Custom,
        [EnumMember(Value = "PLAYFAB")] PlayFab,
        [EnumMember(Value = "NONE")] None

#if !UNITY_2017_1_OR_NEWER
        Server
#endif
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyApiEndpoint
    {
        [EnumMember(Value = "NONE")] None,
        [EnumMember(Value = "AUTH")] Auth,
        [EnumMember(Value = "WALLET")] Wallet,
        [EnumMember(Value = "EXT")] Extension,
        [EnumMember(Value = "NFT")] Nft,
        [EnumMember(Value = "MARKET")] Market,
        //Matic,
        //Bsc,
        //Ethereum
    }

    [JsonConverter(typeof(SupportedChainConverter))]
    public enum eVyChain
    {
        [EnumMember(Value = "INVALID")] NotSupported,
        [EnumMember(Value = "BSC")] Bsc,
        [EnumMember(Value = "ETHEREUM")] Ethereum,
        [EnumMember(Value = "AVAC")] Avac,
        [EnumMember(Value = "MATIC")] Matic
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyChainFULL
    {
        [EnumMember(Value = "AETERNITY")] Aeternity,
        [EnumMember(Value = "AVAC")] Avac,
        [EnumMember(Value = "BITCOIN")] Bitcoin,
        [EnumMember(Value = "BSC")] Bsc,
        [EnumMember(Value = "ETHEREUM")] Ethereum,
        [EnumMember(Value = "GOCHAIN")] Gochain,
        [EnumMember(Value = "HEDERA")] Hedera,
        [EnumMember(Value = "LITECOIN")] Litecoin,
        [EnumMember(Value = "TRON")] Tron,
        [EnumMember(Value = "VECHAIN")] Vechain,
        [EnumMember(Value = "MATIC")] Matic,
        [EnumMember(Value = "NEO")] Neo,
        [EnumMember(Value = "IMX")] ImmutableX
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyWalletType
    {
        //[EnumMember(Value = "WATCH_ONLY")] WatchOnly,
        //[EnumMember(Value = "THREEWAY_SHARED")] ThreewayShared,
        //[EnumMember(Value = "USER_OWNED")] UserOwned,
        //[EnumMember(Value = "UNCLAIMED")] Unclaimed,
        //[EnumMember(Value = "APPLICATION")] Application,
        [EnumMember(Value = "WHITE_LABEL")] WhiteLabel,
        [EnumMember(Value = "UNRECOVERABLE_WHITE_LABEL")] WhiteLabelUnrecoverable,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyTransactionStatus
    {
        [EnumMember(Value = "UNKNOWN")] Unknown,
        [EnumMember(Value = "PENDING")] Pending,
        [EnumMember(Value = "FAILED")] Failed,
        [EnumMember(Value = "SUCCEEDED")] Succeeded,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyExchange
    {
        [EnumMember(Value = "AVAX_WAVAX")] Avax_Wavax,
        [EnumMember(Value = "BSC_WBNB")] Bsc_Wbnb,
        [EnumMember(Value = "VEXCHANGE")] VexChange,
        [EnumMember(Value = "UNISWAP")] Uniswap,
        [EnumMember(Value = "TOTLE")] Totle,
        [EnumMember(Value = "ONE_INCH")] One_Inch,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyOrderType
    {
        [EnumMember(Value = "SELL")] Sell,
        [EnumMember(Value = "BUY")] Buy
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyStorageType
    {
        [EnumMember(Value = "CLOUD")] Cloud,
        [EnumMember(Value = "IPFS")] IPFS,
        [EnumMember(Value = "CUSTOM")] Custom
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eVyTokenAttributeType
    {
        [EnumMember(Value = "stat")] Stat,
        [EnumMember(Value = "property")] Property,
        [EnumMember(Value = "boost")] Boost,
        [EnumMember(Value = "system")] System
    }
}