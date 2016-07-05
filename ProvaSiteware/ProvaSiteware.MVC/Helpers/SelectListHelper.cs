using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel;
using Lab.Domain.Common.Helpers;
using System.Linq.Expressions;

namespace Lab.Presentation.MVC.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> ToSelectList<TEnum>(TEnum? selectedValue = null) where TEnum : struct
        {
            var listItem = new List<SelectListItem>();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                listItem.Add(new SelectListItem()
                {
                    Text = EnumHelper.GetEnumDescription<TEnum>(value),
                    Value = (Convert.ToInt32(value)).ToString(),
                    Selected = value.Equals(selectedValue)
                });
            }
            
            return listItem;
        }
    }
}