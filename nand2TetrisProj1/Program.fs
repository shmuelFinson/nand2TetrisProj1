// Learn more about F# at http://fsharp.org
// add a coment
//Hi this is a comment!!!!!!

open System
open System.IO




[<EntryPoint>]
let main argv =
   
   //pop functions:

    //pop segment(local/argument/this/that) offset  - pop #1

    //pop segment(pointer/temp) offset - pop #2

    //pop static offset - pop #3

    //pop constant offset - pop #4

    // push functions:

    //push segment(local/argument/this/that) offset  - push #1
    let push_Lcl_Arg_This_That_Offset (register:string , offset:string) = 
        printf "@%A\n" offset
        printf "D=A\n"
        printf "@%A\n" register
        printf "A=M+D\n"
        printf "D=M\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"

    //push (pointer/temp) offset  - push #2

    //push static offset - push #3
    let push_static_offset(register:string , offset:string) = 
        printf "\n"
        printf "//push %A %A \n"  register offset
        printf "@%A\n" offset
        printf "D=A\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"
        printf "\n"
    
    //push constant value - push #4




    //translate a push command into HACK
    let pushHackCommand (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None) //push - 0 constant - 1 2 - 2
        let sourceReg = hackCode.[1] //name of register 
        let offset = hackCode.[2] //address in register

        match sourceReg with
                    |"local" ->  push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"argument" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"this" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"that" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"static" -> push_static_offset (sourceReg, offset)
                    |_ ->  printf "Unknown\n"

       


    //translate a pop command into HACK
    let popHackCommand (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
        let a = hackCode.[1]
        let b = hackCode.[2]
        printf "pop %A to %A\n" a b

    //translate an add command into HACK
    let addHackCommand (lineOfCode:string) = 
       // let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
       // let a = hackCode.[1]
       // let b = hackCode.[2]
        printf "//add\n"
        printf "@SP\n"
        printf "M=M-1\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "D=M\n"
        printf "@SP\n"
        printf "M=M-1\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "D=D+A\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"



    //translate a sub command into HACK
    let subHackCommand (lineOfCode:string) = 
              printf "//sub\n"
              printf "@SP\n"
              printf "M=M-1\n"
              printf "@SP\n"
              printf "A=M\n"
              printf "D=M\n"
              printf "@SP\n"
              printf "M=M-1\n"
              printf "@SP\n"
              printf "A=M\n"
              printf "A=M\n"
              printf "D=A-D\n"
              printf "@SP\n"
              printf "A=M\n"
              printf "M=D\n"
              printf "@SP\n"
              printf "M=M+1\n"
              

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
