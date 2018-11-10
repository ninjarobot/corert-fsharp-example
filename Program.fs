open System
open System.Net.Http
open System.Security.Cryptography
open System.Text
open Mono.Options

[<EntryPoint>]
let main argv =
    let cliOpts = OptionSet()
    let mutable (url:string) = null
    cliOpts.Add("url=", fun x -> url <- x) |> ignore

    let mutable (stringToHash:string) = null
    cliOpts.Add("hashme=", fun x -> stringToHash <- x) |> ignore

    cliOpts.Parse argv |> ignore 

    if String.IsNullOrWhiteSpace stringToHash && String.IsNullOrWhiteSpace url then
        Console.WriteLine "Usage: littleClient [args]"
        cliOpts.WriteOptionDescriptions Console.Out
    else
        if not (isNull url) then
            use http = new HttpClient ()
            async {
                let! res = http.GetAsync url |> Async.AwaitTask
                let! content = res.Content.ReadAsStringAsync () |> Async.AwaitTask
                Console.WriteLine content
            } |> Async.RunSynchronously
        elif not (isNull stringToHash) then
            use alg = SHA256.Create ()
            stringToHash
            |> Encoding.UTF8.GetBytes
            |> alg.ComputeHash
            |> Convert.ToBase64String
            |> Console.WriteLine
    0 // return an integer exit code
