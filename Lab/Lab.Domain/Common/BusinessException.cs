using Lab.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Common
{
    public class BusinessException : Exception
    {
        public IEnumerable<ValidationResult> ValidationResults { get; private set; }

        public BusinessException(IEnumerable<ValidationResult> validationResults)
            : base("Resource.SomeBusinessRulesWasViolated")
        {
            ValidationResults = validationResults;
        }

        public BusinessException(string message)
            : base(message)
        {
            ValidationResults = new List<ValidationResult>();
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationResults = new List<ValidationResult>();
        }

        public override string Message
        {
            get
            {
                var errorStringBuilder = new StringBuilder();

                foreach (var businessRuleViolation in ValidationResults)
                    errorStringBuilder.AppendFormat($"{businessRuleViolation.MemberNames} : {businessRuleViolation.ErrorMessage}{Environment.NewLine}");

                return base.Message + (errorStringBuilder.Length > 0 ? Environment.NewLine + errorStringBuilder : string.Empty);
            }
        }
    }
}
