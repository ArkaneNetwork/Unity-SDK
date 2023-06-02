using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using Venly.Data;
using Venly.Editor.Utils;

namespace Venly.Editor.Tools.Controls
{
    public class TokenAttributeList : ControlBaseRW
    {
        private VisualElement _itemContainer;
        private Button _btnAddItem;

        private VyTokenTypeSO _tokenItem;
        private SerializedObject _serializedItem;
        private SerializedProperty _listProperty;

        private Label _lblName;
        public string ListName { get; private set; }
        public string BindingPath { get; private set; }

        public new class UxmlFactory : UxmlFactory<TokenAttributeList, UxmlTraits>
        {

        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription m_ListName = new() { name = "list-name", defaultValue = "Label" };
            UxmlStringAttributeDescription m_BindingPath = new() { name = "binding-path", defaultValue = "" };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                ((TokenAttributeList)ve).ListName = m_ListName.GetValueFromBag(bag, cc);
                ((TokenAttributeList)ve).BindingPath = m_BindingPath.GetValueFromBag(bag, cc);
                ((TokenAttributeList)ve).RefreshControl();
            }
        }

        public TokenAttributeList()
        {
            var root = VenlyEditorUtils.GetUXML_Controls("TokenAttributeList");
            root.CloneTree(this);

            _lblName = this.Q<Label>("lbl-name");

            _itemContainer = this.Q<VisualElement>("item-container");
            _btnAddItem = this.Q<Button>("btn-add-item");
            _btnAddItem.clickable.clicked += onClick_ItemAdd;
        }

        private void onClick_ItemAdd()
        {
            _listProperty.InsertArrayElementAtIndex(_listProperty.arraySize);

            //Reset Value
            var objRef = _listProperty.GetArrayElementAtIndex(_listProperty.arraySize - 1);
            objRef.FindPropertyRelative("Type").enumValueIndex = 0;
            objRef.FindPropertyRelative("Name").stringValue = "";
            objRef.FindPropertyRelative("Value").stringValue = "";

            _serializedItem.ApplyModifiedProperties();

            RefreshControl();
        }

        private void onClick_ItemRemove(EventBase eventArgs)
        {
            if(eventArgs.target is Button btn)
            {
                var itemIndex = (int)btn.userData;
                _listProperty.DeleteArrayElementAtIndex(itemIndex);
                _serializedItem.ApplyModifiedProperties();

                RefreshControl();
            }
        }

        public void BindItemSource(VyTokenTypeSO token)
        {
            _tokenItem = token;
            _serializedItem = new SerializedObject(token);

            RefreshControl();
        }

        public void RefreshControl()
        {
            _itemContainer.Clear();
            _lblName.text = ListName;

            if (_tokenItem == null || string.IsNullOrEmpty(BindingPath))
                return;

            _listProperty = _serializedItem.FindProperty(BindingPath);
            if (_listProperty == null || !_listProperty.isArray)
            {
                _listProperty = null;
                return;
            }

            for (var i = 0; i < _listProperty.arraySize; ++i)
            {
                var listElement = _listProperty.GetArrayElementAtIndex(i);

                var itemControl = new TokenAttributeItem();
                itemControl.BindProperty(listElement);

                var removeBtn = itemControl.Q<Button>("btn-item-remove");
                removeBtn.userData = i;
                removeBtn.clickable.clickedWithEventInfo += onClick_ItemRemove;

                _itemContainer.Add(itemControl);
            }
        }

        public override void RefreshMode(eEditMode mode)
        {
            foreach (var element in _itemContainer.Children())
            {
                if (element is ControlBaseRW controlBase)
                {
                    controlBase.RefreshMode(mode);
                }
            }

            _btnAddItem.ToggleElement(mode == eEditMode.Write);
        }
    }
}