using System;
using Machine.Specifications;

namespace NiceTry.Tests.Combinators {
    [Subject(typeof (NiceTry.Combinators), "OrElse")]
    class
        When_I_try_to_add_two_and_three_and_would_try_to_add_one_and_three_if_the_calculation_failed {
        static ITry<int> _result;
        
        Because of = () => _result = Try.To(() => 2 + 3)
                                        .OrElse(() => 1 + 3);

        It should_contain_five_in_the_success = () => _result.Value.ShouldEqual(5);

        It should_return_a_success = () => _result.IsSuccess.ShouldBeTrue();
    }
}