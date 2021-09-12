using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace api_fullstack_challenge.Util
{
    public static class Helper
    {
        public static string GetDescription(System.Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString()).FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }

        public static T GetValueFromDescription<T>(string Id)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == Id)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == Id)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }

        public static string GetDescriptionFromValueName<T>(string value)
        {
            try
            {
                var type = typeof(T);
                var r = type.GetFields().FirstOrDefault(x => x.Name == value);
                if (Attribute.GetCustomAttribute(r, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    return attribute.Description;
                }
                else return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}

