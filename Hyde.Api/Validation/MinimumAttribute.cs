using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Hyde.Api.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinimumAttribute : ValidationAttribute
    {
        private readonly IComparable _minimumValue;

        public MinimumAttribute(object value)
            : base("字段 {0} 必须大于等于 {1}")
        {
            _minimumValue = value as IComparable;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                base.ErrorMessageString,
                name,
                _minimumValue);
        }

        public override bool IsValid(object value)
        {

            IComparable InitValue;
            if (value != null)
            {
                InitValue = value as IComparable;
                return InitValue.CompareTo(_minimumValue) >= 0;
            }

            return false;
        }
    }
}