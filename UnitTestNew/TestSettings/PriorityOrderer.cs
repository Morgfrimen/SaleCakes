using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTestNew.TestSettings;

public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var assemblyName = typeof(PriorityTestAttribute).AssemblyQualifiedName!;
        SortedDictionary<int, List<TTestCase>>? sortedMethods = new();

        foreach (var testCase in testCases)
        {
            var priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(PriorityTestAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (var testCase in
                 sortedMethods.Keys.SelectMany(
                     priority => sortedMethods[priority]
                         .OrderBy(
                             testCase => testCase.TestMethod.Method.Name)))
            yield return testCase;
    }

    private static TValue GetOrCreate<TKey, TValue>(
        IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : struct
        where TValue : new()
    {
        return dictionary.TryGetValue(key, out var result)
            ? result
            : dictionary[key] = new TValue();
    }
}