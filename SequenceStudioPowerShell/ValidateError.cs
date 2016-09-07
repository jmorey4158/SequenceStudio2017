using System.Management.Automation;
using System;
using System.Collections;

namespace SequenceStudioPowerShell
{ 
    public static class ValidationError
    {
        public static ErrorRecord ThrowError(String message, String recommendedAction,
            String reason, String activity, String target, String targetType)
        {
            ValidationMetadataException ve = new ValidationMetadataException(message);

            ErrorRecord er = new ErrorRecord(
                ve,
                message,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = activity;
            er.CategoryInfo.Reason = reason;
            er.CategoryInfo.TargetName = target;
            er.CategoryInfo.TargetType = targetType;

            ErrorDetails ed = new ErrorDetails(message);
            ed.RecommendedAction = recommendedAction;
            er.ErrorDetails = ed;

            return er;
        }

        public static ErrorRecord ThrowTerminatingError(String message, String recommendedAction,
            String reason, String activity, String target, String targetType)
        {
            ValidationMetadataException ve = new ValidationMetadataException(message);

            ErrorRecord er = new ErrorRecord(
                ve,
                message,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = activity;
            er.CategoryInfo.Reason = reason;
            er.CategoryInfo.TargetName = target;
            er.CategoryInfo.TargetType = targetType;

            ErrorDetails ed = new ErrorDetails(message);
            ed.RecommendedAction = recommendedAction;
            er.ErrorDetails = ed;

            return er;
        }
    }
}