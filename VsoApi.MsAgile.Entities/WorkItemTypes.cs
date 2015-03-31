namespace VsoApi.MsAgile.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public enum WorkItemTypes
    {
        [Display(Name = "Bug")]
        Bug,

        [Display(Name = "Issue")]
        Issue,

        [Display(Name = "Code Review Request")]
        CodeReviewRequest,

        [Display(Name = "Code Review Response")]
        CodeReviewResponse,

        [Display(Name = "Feature")]
        Feature,

        [Display(Name = "Feedback Request")]
        FeedbackRequest,

        [Display(Name = "Feedback Response")]
        FeedbackResponse,

        [Display(Name = "Shared Parameter")]
        SharedParameter,

        [Display(Name = "Shared Steps")]
        SharedSteps,

        [Display(Name = "Task")]
        Task,

        [Display(Name = "Test Case")]
        TestCase,

        [Display(Name = "Test Plan")]
        TestPlan,

        [Display(Name = "Test Suite")]
        TestSuite,

        [Display(Name = "User Story")]
        UserStory,
    }

    public static class WorkItemTypesExtensions
    {
        public static WorkItemTypes ConvertToEnum(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            string valueWithoutSpaces = value.Replace(" ", "");
            return (WorkItemTypes) Enum.Parse(typeof (WorkItemTypes), valueWithoutSpaces);
        }

        private static TValue GetAttributeValue<TAttribute, TValue>(this Enum enumeration, Func<TAttribute, TValue> expression) where TAttribute : Attribute
        {
            MemberInfo enumField = enumeration.GetType().GetMember(enumeration.ToString()).Single();
            TAttribute attribute = enumField.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>().SingleOrDefault();

            if (attribute == null)
                return default(TValue);

            return expression(attribute);
        }

        public static string DisplayName(this Enum enumeration)
        {
            return enumeration.GetAttributeValue<DisplayAttribute, string>(attr => attr.Name);
        }
    }
}