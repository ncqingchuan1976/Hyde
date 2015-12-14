using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace Hyde.Api.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MaximumAttribute : ValidationAttribute
    {
        private readonly IComparable _maximumValue;

        public MaximumAttribute(object value)
            : base("字段 {0} 必须小于等于 {1}")
        {
            _maximumValue = value as IComparable;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _maximumValue);
        }

        public override bool IsValid(object value)
        {
            IComparable InitValue;
            if (value != null)
            {
                InitValue = value as IComparable;
                return InitValue.CompareTo(_maximumValue) <= 0;
            }

            return false;
        }
    }
}