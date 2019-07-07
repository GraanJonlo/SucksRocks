#load ".fake/build.fsx/intellisense.fsx"

open System

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let appPath = "./src/SucksRocks/" |> Path.getFullName

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "Run" (fun _ ->
    let server = async {
        DotNet.exec (fun p -> {p with WorkingDirectory = appPath}) "watch run" ""
        |> ignore
    }
    let browser = async {
        Threading.Thread.Sleep 5000
        Diagnostics.Process.Start "http://localhost:8080" |> ignore
    }
    [ server; browser]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
)

"Clean"
    ==> "Build"
    ==> "Run"

Target.runOrDefault "Build"
