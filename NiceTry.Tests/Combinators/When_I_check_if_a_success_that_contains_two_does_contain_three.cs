using System;
using Machine.Specifications;

namespace NiceTry.Tests.Combinators {
    [Subject(typeof (NiceTry.Combinators), "Filter")]
    class When_I_check_if_a_success_that_contains_two_does_contain_three {
        static ITry<int> _twoSuccess;
        static ITry<int> _result;
        static Func<int, bool> _containsThree;

        Establish context = () => {
            _twoSuccess = new Success<int>(2);
            _containsThree = i => i == 3;
        };

        Because of = () => _result = _twoSuccess.Filter(_containsThree);

        It should_contain_an_ArgumentException_in_the_failure =
            () => _result.Error.ShouldBeOfType<ArgumentException>();

        It should_return_a_failure_success = () => _result.IsFailure.ShouldBeTrue();
    }
}