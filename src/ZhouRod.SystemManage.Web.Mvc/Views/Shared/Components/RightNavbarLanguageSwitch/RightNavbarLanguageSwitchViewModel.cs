﻿using System.Collections.Generic;
using Abp.Localization;

namespace ZhouRod.SystemManage.Web.Views.Shared.Components.RightNavbarLanguageSwitch
{
    public class RightNavbarLanguageSwitchViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}
