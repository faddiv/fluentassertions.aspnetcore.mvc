﻿using System;
using System.Diagnostics;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="CreatedAtRouteResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class CreatedAtRouteResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CreatedAtRouteResultAssertions" /> class.
        /// </summary>
        public CreatedAtRouteResultAssertions(CreatedAtRouteResult subject) : base(subject) { }

        /// <summary>
        /// Asserts that the redirect has the expected route name.
        /// </summary>
        /// <param name="expectedRouteName">The expected route name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public CreatedAtRouteResultAssertions WithRouteName(string expectedRouteName, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as CreatedAtRouteResult;

            Execute.Assertion
                .BecauseOf(reason, reasonArgs)
                .ForCondition(string.Equals(expectedRouteName, subjectTyped.RouteName, StringComparison.OrdinalIgnoreCase))
                .WithDefaultIdentifier("CreatedAtRouteResult.RouteName")
                .FailWith(FailureMessages.CommonFailMessage, expectedRouteName, subjectTyped.RouteName);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route value.
        /// </summary>
        /// <param name="key">The expected key.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public CreatedAtRouteResultAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var subjectTyped = Subject as CreatedAtRouteResult;

            AssertionHelpers.AssertStringObjectDictionary(subjectTyped.RouteValues, "CreatedAtRouteResult.RouteValues", 
                key, expectedValue, reason, reasonArgs);

            return this;
        }

        /// <summary>
        ///     Asserts the value is of the expected type.
        /// </summary>
        /// <typeparam name="TValue">The expected type.</typeparam>
        /// <returns>The typed value.</returns>
        public TValue ValueAs<TValue>()
        {
            var subjectTyped = Subject as CreatedAtRouteResult;
            var value = subjectTyped.Value;

            if (value == null)
                Execute.Assertion
                    .WithDefaultIdentifier("CreatedAtRouteResult.Value")
                    .FailWith(FailureMessages.CommonNullWasSuppliedFailMessage, typeof(TValue));

            Execute.Assertion
                .ForCondition(value is TValue)
                    .WithDefaultIdentifier("CreatedAtRouteResult.Value")
                .FailWith(FailureMessages.CommonTypeFailMessage, typeof(TValue), value.GetType());

            return (TValue)value;
        }
    }
}
