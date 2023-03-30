using UnityEngine.UIElements;
using VenlySDK.Models;

//ITEM
public class VyControl_MultiTokenListItem : VyControl_ListViewItemBase<VyMultiTokenDto>
{
    public VyControl_MultiTokenListItem() : base("VyControl_MultiTokenListItem") { }

    public override void BindItem(VyMultiTokenDto sourceItem)
    {
        if (sourceItem.HasAttribute("mintNumber"))
        {
            SetLabel("lbl-name", $"{sourceItem.Name} (#{sourceItem.GetAttribute("mintNumber").As<int>()})");
        }
        else
        {
            SetLabel("lbl-name", sourceItem.Name);
        }
       
        SetLabel("lbl-id", sourceItem.Id);
        SetLabel("lbl-fungible", sourceItem.Fungible);
        SetLabel("lbl-type", sourceItem.Contract.Type);
    }

    public override void BindMockItem()
    {
        SetLabel("lbl-name", "Mock Name");
        SetLabel("lbl-id", "123");
        SetLabel("lbl-fungible", "YES");
        SetLabel("lbl-type", "ERC 1155");
    }
}

//LIST VIEW
public class VyControl_MultiTokenListView : VyControl_ListViewBase<VyMultiTokenDto, VyControl_MultiTokenListItem>
{
    public new class UxmlFactory : UxmlFactory<VyControl_MultiTokenListView, UxmlTraits> { }
}