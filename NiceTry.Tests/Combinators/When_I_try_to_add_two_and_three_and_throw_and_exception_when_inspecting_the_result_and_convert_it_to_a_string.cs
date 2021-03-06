using System;
using System.Globalization;
using Machine.Specifications;

namespace NiceTry.Tests.Combinators {
    [Subject(typeof (NiceTry.Combinators), "Inspect")]
    class When_I_try_to_add_two_and_three_and_throw_and_exception_when_inspecting_the_result_and_convert_it_to_a_string {
        static ITry<string> _result;

        Because of = () => _result = Try.To(() => 2 + 3)
                                        .Inspect(_ => { throw new Exception("Expected test exception"); })
                                        .Map(i => i.ToString(CultureInfo.InvariantCulture));

        It should_contain_five_as_string_in_the_success =
            () => _result.Value.ShouldEqual("5");

        It should_return_a_success =
            () => _result.IsSuccess.ShouldBeTrue();
    }
}