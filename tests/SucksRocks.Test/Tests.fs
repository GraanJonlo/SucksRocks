module Tests

open Xunit
open FsUnit.Xunit

open SucksRocks

[<Fact>]
let ``When I search for Microsoft and Apple then Apple should have a higher score`` () =
    (RockScore.forTerm "Apple") |> should greaterThan (RockScore.forTerm "Microsoft")
