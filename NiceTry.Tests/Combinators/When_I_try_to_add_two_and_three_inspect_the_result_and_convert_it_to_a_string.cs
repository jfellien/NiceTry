using System.Globalization;
using Machine.Specifications;

namespace NiceTry.Tests.Combinators {
    [Subject(typeof (NiceTry.Combinators), "Inspect")]
    class When_I_try_to_add_two_and_three_inspect_the_result_and_convert_it_to_a_string {
        static ITry<string> _result;
        static int _five;

        Because of = () => _result = Try.To(() => 2 + 3)
                                        .Inspect(i => _five = i)
                                        .Map(i => i.ToString(CultureInfo.InvariantCulture));

        It should_return_five_as_a_string =
            () => _result.Value.ShouldEqual("5");

        It should_set_the_result_of_the_inspection_to_five_as_int =
            () => _five.ShouldEqual(5);
    }
}