using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using ProvaSiteware.Domain.Common.Helpers;

namespace ProvaSiteware.MVC.Common
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

            //var teste =
            //    (from p in Enum.GetValues(typeof(TEnum))
            //     select new
            //     {
            //         Text = EnumHelper.GetEnumDescription<TEnum>(p),
            //         Value = p
            //     });


            return listItem;
        }
    }
}