using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using VenlySDK.Models;

namespace VenlySDK.Data
{
    public class VyTokenTypeSO : VyItemSO
    {
        [Serializable]
        public class _TokenAttribute
        {
            public eVyTokenAttributeType Type = eVyTokenAttributeType.Property;
            public string Name = "";
            public string Value = "";

            public VyTokenAttribute ToModel()
            {
                return new VyTokenAttribute()
                {
                    Type = Type,
                    Name = Name,
                    Value = Value
                };
            }

            public static _TokenAttribute FromModel(VyTokenAttribute att)
            {
                return new _TokenAttribute()
                {
                    Type = att.Type,
                    Name = att.Name,
                    Value = att.Value as string //todo> fix type
                };
            }
        }


        internal override eVyItemType ItemType => eVyItemType.TokenType;
        public VyContractSO Contract;

        #region TokenType Fields

        [VyItemField(eVyItemTrait.LiveReadOnly)]
        public string ImageThumbnail;

        [VyItemField(eVyItemTrait.LiveReadOnly)]
        public string ImagePreview;

        [VyItemField(eVyItemTrait.LiveReadOnly)]
        public long CurrentSupply;

        [VyItemField] public bool Fungible;
        [VyItemField] public bool Burnable;
        [VyItemField] public int MaxSupply;

        [VyItemField(eVyItemTrait.Updateable)] public string BackgroundColor;
        [VyItemField(eVyItemTrait.Updateable)] public List<_ItemTypeValue> AnimationUrls = new();
        [VyItemField(eVyItemTrait.Updateable)] public List<_TokenAttribute> Attributes = new();

        public string TextureUrl;
        public Texture2D TokenTexture;
        public event Action<Texture2D> OnTextureChanged;

        #endregion

        public VyTokenTypeDto ToModel()
        {
            return new VyTokenTypeDto
            {
                Name = Name,
                AnimationUrls = AnimationUrls.Select(e => e.ToModel()).ToArray(),
                Attributes = Attributes.Select(e => e.ToModel()).ToArray(),
                BackgroundColor = BackgroundColor,
                Burnable = Burnable,
                MaxSupply = MaxSupply,
                Confirmed = Confirmed,
                CurrentSupply = CurrentSupply,
                Description = Description,
                ExternalUrl = ExternalUrl,
                Fungible = Fungible,
                Id = Id,
                Image = ImageUrl,
                ImagePreview = ImagePreview,
                ImageThumbnail = ImageThumbnail,
                TransactionHash = TransactionHash
            };
        }

#if UNITY_EDITOR
        public void UpdateLiveModel(VyTokenTypeDto model)
        {
            LiveModel = JsonConvert.SerializeObject(model ?? ToModel());
        }

        public void NotifyTextureUpdated()
        {
            OnTextureChanged?.Invoke(TokenTexture);
        }
#endif
    }
}