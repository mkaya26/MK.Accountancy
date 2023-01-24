using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.SpecialCodes;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class SpecialCodeService : BaseService<ListSpecialCodeDto, SelectSpecialCodeDto>, IScopedDependency
    {
        public SpecialCodeType SpecialCodeType { get; private set; }
        public CardType CardType { get; private set; }
        public override void SelectEntity(IEntityDto targetEntity)
        {
            var specialCode = (ISpecialCode)targetEntity;
            //
            switch (SpecialCodeType)
            {
                case SpecialCodeType.SpecialCodeOne:
                    specialCode.SpecialCodeOneId = SelectedItem?.Id;
                    specialCode.SpecialCodeOneName = SelectedItem?.Name;
                    break;
                case SpecialCodeType.SpecialCodeTwo:
                    specialCode.SpecialCodeTwoId = SelectedItem?.Id;
                    specialCode.SpecialCodeTwoName = SelectedItem?.Name;
                    break;
            }
        }

        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            ToolbarCheckBoxVisible = false;
            IsPopupListPage = true;
            //
            SpecialCodeType = (SpecialCodeType)parameters[0];
            CardType = (CardType)parameters[1];
            PopupListPageFocusedRowId = parameters[2] == null ? Guid.Empty : (Guid)parameters[2];
        }

        public override void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName)
        {
            var specialCode = (ISpecialCode)entity;
            //
            switch (fieldName)
            {
                case nameof(specialCode.SpecialCodeOneName):
                    specialCode.SpecialCodeOneId = null;
                    specialCode.SpecialCodeOneName = null;
                    break;
                case nameof(specialCode.SpecialCodeTwoName):
                    specialCode.SpecialCodeTwoId = null;
                    specialCode.SpecialCodeTwoName = null;
                    break;
            }
        }
    }
}
