//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Web;

//namespace oagum0._01.extrafiles
//{
//    public class ExpandoObject
//    {
//        public  ExpandoObject ToExpando(this object anonymousObject)
//        {
//            IDictionary<string, object> expando = new ExpandoObject();
//            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
//            {
//                var obj = propertyDescriptor.GetValue(anonymousObject);
//                expando.Add(propertyDescriptor.Name, obj);
//            }
//            return (ExpandoObject)expando;
//        }
//    }
//}