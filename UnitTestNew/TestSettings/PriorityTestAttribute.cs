using System;

namespace UnitTestNew.TestSettings;

[AttributeUsage(AttributeTargets.Method)]
public class PriorityTestAttribute : Attribute
{
    public PriorityTestAttribute(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; }
}