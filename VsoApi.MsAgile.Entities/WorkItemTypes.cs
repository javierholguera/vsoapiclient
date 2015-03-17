namespace VsoApi.MsAgile.Entities
{
    using System;

    public enum WorkItemTypes
    {
        Bug,
        Issue,
        CodeReviewRequest,
        CodeReviewResponse,
        Feature,
        FeedbackRequest,
        FeedbackResponse,
        SharedParameter,
        SharedSteps,
        Task,
        TestCase,
        TestPlan,
        TestSuite,
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
    }
}