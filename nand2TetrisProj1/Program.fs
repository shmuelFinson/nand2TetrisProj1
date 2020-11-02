// Learn more about F# at http://fsharp.org
// add a coment
//Hi this is a comment!!!!!!

open System
open System.IO

type Color =
        | push = 0
        | pop = 1


[<EntryPoint>]
let main argv =
   

    
    

    //let checkType command = 
      

    
    let pushHackCommand (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
        let sourceReg = hackCode.[1] //name of register 
        let address = hackCode.[2] //address in register
        printf "\n"
        printf "//push %A %A \n"  sourceReg address
        printf "@%A\n" address
        printf "D=A\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"
        printf "\n"



    let popHackCommand (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
        let a = hackCode.[1]
        let b = hackCode.[2]
        printf "pop %A to %A\n" a b

    let addHackCommand (lineOfCode:string) = 
       // let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
       // let a = hackCode.[1]
       // let b = hackCode.[2]
        printf "add\n"

    let subHackCommand (lineOfCode:string) = 
              printf "sub\n"

    //read the file into a string
    let lines = File.ReadAllLines(@"C:\Users\Shmuel Finson\Desktop\aFile.txt")
    // Convert file lines into a list.
    let commands = Seq.toList lines

    //iterate over the lines in the file and call our functions for each line

    for command in commands do  //we have a string per line of code
        let firstWord = command.Split([|" "|], StringSplitOptions.None)  //get the first word in the string to determine what kind of command we're talking about
        match firstWord.[0] with
             |"push" ->  pushHackCommand command
             |"pop" -> popHackCommand command
             |"add" -> addHackCommand command
             |"sub" -> subHackCommand command
             |_ ->  printf "Unknown\n"
        
        

        

       



         

  


    



  
//printfn "%A\n" commands
    0 // return an integer exit code
