namespace SucksRocks.Server

//module Fing =
//    open Microsoft.Azure.CognitiveServices.Search.WebSearch

//    let searchCount apiKey endpoint query =
//        let client = new WebSearchClient(ApiKeyServiceClientCredentials(apiKey))
//        client.Endpoint <- endpoint

//        async {
//            let! webData = Async.AwaitTask <| client.Web.SearchAsync(query=query)

//            let count = webData.WebPages.TotalEstimatedMatches
//            if count.HasValue then
//                return Some count.Value
//            else
//                return None
//        }

//[<Fact>]
//let ``Exploratory test for Bing`` () =
//    async {
//        let! foo = Fing.searchCount "<INSERT APP KEY HERE>" @"https://northeurope.api.cognitive.microsoft.com" "Yosemite National Park"
//        match foo with
//        | None -> shouldFail id
//        | Some number -> number |> should greaterThan (int64 10)
//    }