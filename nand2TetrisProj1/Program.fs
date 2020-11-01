// Learn more about F# at http://fsharp.org
// add a coment
//Hi this is a comment!!!!!!

open System
open System.IO

[<EntryPoint>]
let main argv =
   

    
    let lines = File.ReadAllLines(@"C:\Users\Shmuel Finson\Desktop\aFile.txt")
    
    // Convert file lines into a list.
    let list = Seq.toList lines
    
    printfn "%A" list
    0 // return an integer exit code
