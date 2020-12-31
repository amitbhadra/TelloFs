// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Net
open System.Net.Sockets
open System.Text
open System.Threading


// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let allCommands = [|"command"; "takeoff"; "land"|]


[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message

    let receivePort = 8889
    printfn "Receive port: %d" receivePort
    
    let receivingClient = new UdpClient(receivePort)
    let ReceivingIpEndPoint = new IPEndPoint(IPAddress.Any, 0)
    
    let sendAddress = IPAddress.Parse("192.168.10.1")
    printfn "Send address: %A" sendAddress
    
    let sendPort = 8889
    printfn "Send port: %d" sendPort
    
    let sendingClient = new UdpClient()
    let sendingIpEndPoint = new IPEndPoint(sendAddress, sendPort)
    
    let receive () = async {
            try
                let! receiveResult = receivingClient.ReceiveAsync() |> Async.AwaitTask
                let receiveBytes = receiveResult.Buffer
                let returnData = Encoding.ASCII.GetString(receiveBytes)
                printfn "%s" returnData
            with
                | error -> printfn "%s" error.Message }
        
    let send () = async {
        printfn "Send message: "
        let (sendBytes: byte array) = Encoding.ASCII.GetBytes(Console.ReadLine())
        try
            sendingClient.Send(sendBytes, sendBytes.Length, sendingIpEndPoint) |> ignore
        with
            | error -> printfn "%s" error.Message }

    let rec loop1() = async {
        do! receive ()
        return! loop1() }

    let rec loop2() = async {
        do! send ()
        return! loop2() }

    loop1() |> Async.Start  
    loop2() |> Async.Start
        
    Console.Read() |> ignore
    

    0 // return an integer exit code
