using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;
using Microsoft.PowerShell.Commands;

namespace SequenceStudioPowerShell
{
    [AttributeUsageAttribute(AttributeTargets.Property)]
    public sealed class ValidateStrand : ValidateArgumentsAttribute
    {
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null || !(arguments is string))
            {

            }
            else
            {

            }
        }
    }
}