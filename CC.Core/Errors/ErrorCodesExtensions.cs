using System;

namespace CC.Core.Errors
{
    public static class ErrorCodesExtensions
    {
        public static string GetDescription(this ErrorCode target)
        {
            var enumName = Enum.GetName(typeof(ErrorCode), target);
            if (enumName == null) throw new NotImplementedException();
            var propertyInfo = typeof(Errors).GetProperty(enumName);
            if (propertyInfo == null)
                throw new NotImplementedException(string.Format(
                    "Add Error description to resource Errors.resx name='{0}'", enumName));
            return propertyInfo.GetValue(null).ToString();
        }
    }


}
