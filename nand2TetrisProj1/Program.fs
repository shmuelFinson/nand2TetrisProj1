// Learn more about F# at http://fsharp.org
// add a coment
//Hi this is a comment!!!!!!

open System
open System.IO




[<EntryPoint>]
let main argv =
   
   //pop functions:

    //pop segment(local/argument/this/that) offset  - pop #1
    let pop_segment_local_argument_this_that_offset(register:string, offset:string) = 
        printf "\n"
        printf "//pop %s %s\n" register offset
        printf "@SP\n"
        printf "M=M-1\n"
        printf "@%s\n" offset
        printf "D=A\n"
        printf "@%s\n" register
        printf "D=M+D\n"
        printf "@R13\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "D=M\n"
        printf "@R13\n"
        printf "A=M\n"
        printf "M=D\n"

    //pop segment(pointer/temp) offset - pop #2
    let pop_segment_pointer_temp_offset(register:string, offset:string) = 
        printf "\n"
        printf "//pop %s %s\n" register offset
        printf "@SP\n" 
        printf "M=M-1\n"
        printf "@%s" offset
        printf "D=A\n"
        //@(3/5)?
        printf "D=A+D\n"
        printf "@R13\n"
        printf "M=D\n"
        printf "@SP\n" 
        printf "A=M\n"
        printf "D=M\n"
        printf "@R13\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "D=M\n"
        printf "@%s\n" offset  //@currentFileName.off -?
        printf "M=D\n"


    //pop static offset - pop #3
    let pop_static_offset(currentFileName:string, offset:string) = 
        printf "\n"
        printf "//pop static %s\n" offset
        printf "@SP\n"
        printf "M=M-1\n"
        printf "@SP\n"
        printf "A=M\n"

    //pop constant offset - pop #4
    let pop_constant_offset(offset:string) = 
        printf "\n"
        printf "//pop constant %s" offset
        printf "@SP\n"
        printf "M=M-1\n"



    // push functions:

    //push segment(local/argument/this/that) offset  - push #1
    let push_Lcl_Arg_This_That_Offset (register:string , offset:string) = 
        printf "@%s\n" offset
        printf "D=A\n"
        printf "@%s\n" register
        printf "A=M+D\n"
        printf "D=M\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"

    //push (pointer/temp) offset  - push #2
    let push_pointer_temp_offest(register:string, offset:string) = 
        printf "'\n"
        printf "//push @%s %s\n" register offset
        printf "@%s\n" offset
        printf "D=A\n"
        //printf "@(3/5)\n"??
        printf "A=A+D\n"
        printf "D=M\n"
        printf "@SP\n"
        printf "A=M\n"
        printf "M=D\n"
        printf "@SP\n"
        printf "M=M+1\n"

    //push static offset - push #3
    let push_static_offset(value:string) =
        let offset = value
        let newLine = "\n"
        let comment = "// push static " + offset + newLine
        let atOffset = "@" + offset + newLine
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset)
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=M
@SP
A=M
M=D
@SP
M=M+1")

  
    
    //push constant value - push #4
    let push_constant_value(value:string)=
        let offset = value
        let newLine = "\n"
        let comment = "// push constant " + offset + newLine
        let atOffset = "@" + offset + newLine
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset)
        File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=A
@SP
A=M
M=D
@SP
M=M+1\n")

        





    //there are several different types of push commands, depending on the register - this function calls the appropriate push function...
    let pushHackCommandSorter (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None) //push - 0 constant - 1 2 - 2
        let sourceReg = hackCode.[1] //name of register 
        let offset = hackCode.[2] //address in register
        //determining the correct push command:
        match sourceReg with
                    |"local" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"argument" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"this" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"that" -> push_Lcl_Arg_This_That_Offset (sourceReg, offset)
                    |"constant" -> push_constant_value(offset)
                    | "static" -> push_static_offset(offset)
                    |_ ->  printf "Unknown\n"

       


   //there are several different types of pop commands, depending on the register - this function calls the appropriate pop function...
    let popHackCommandSorter (lineOfCode:string) = 
        let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
        let sourceReg = hackCode.[1]
        let offset = hackCode.[2]
        //determining the correct pop command:
        match sourceReg with
                    |"local" -> pop_segment_local_argument_this_that_offset (sourceReg, offset)
                    |"argument" -> pop_segment_local_argument_this_that_offset (sourceReg, offset)
                    |"this" -> pop_segment_local_argument_this_that_offset (sourceReg, offset)
                    |"that" -> pop_segment_local_argument_this_that_offset (sourceReg, offset)
                    |"constant" -> pop_constant_offset(offset)
                    |_ ->  printf "Unknown\n"

    //translate an add command into HACK
    let add_2_hack (lineOfCode:string) = 
       // let hackCode = lineOfCode.Split([|" "|], StringSplitOptions.None)
       // let a = hackCode.[1]
       // let b = hackCode.[2]
       File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm" 
,"\n
//add
@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
D=D+A
@SP
A=M
M=D
@SP
M=M+1\n")



    //translate a sub command into HACK
    let sub_2_hack (lineOfCode:string) = 
         File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"\n
//sub
@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
A=M
D=A-D
@SP
A=M
M=D
@SP
M=M+1")
              

    //read the file into a string
    let lines = File.ReadAllLines(@"C:\Users\Shmuel Finson\Desktop\aFile.txt")
    // Convert file lines into a list.
    let commands = Seq.toList lines

    //iterate over the lines in the file and call our functions for each line
    for command in commands do  //we have a string per line of code
        let firstWord = command.Split([|" "|], StringSplitOptions.None)  //get the first word in the string to determine what kind of command we're talking about
        match firstWord.[0] with
             |"push" ->  pushHackCommandSorter command
             |"pop" -> popHackCommandSorter command
             |"add" -> add_2_hack command
             |"sub" -> sub_2_hack command
             |_ ->  printf "Unknown\n"
        
        

        

       



         

  


    



  
//printfn "%A\n" commands
    0 // return an integer exit code
