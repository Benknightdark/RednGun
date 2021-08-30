using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RedGunMVVM.Services
{
    public class CommonService
    {
        /// <summary>
        /// 合併Objects
        /// </summary>
        /// <param name="AContext"></param>
        /// <param name="BContext"></param>
        /// <returns></returns>
        public object MergeObject(object AContext, object BContext)
        {
            var PrevContext = AContext;

            Type AContextType = PrevContext.GetType();
            IList<PropertyInfo> ContextTypeProps = new List<PropertyInfo>(AContextType.GetProperties());

            Type BContextType = BContext.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(BContextType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var SelectedData = ContextTypeProps.Where(a => a.Name == prop.Name);
                if (SelectedData.Any())
                {
                    object propValue = prop.GetValue(BContext, null);
                    AContextType.GetProperty(prop.Name).SetValue(PrevContext, propValue, null);
                }
            }
            AContext = PrevContext;
            return AContext;
        }
    }
}