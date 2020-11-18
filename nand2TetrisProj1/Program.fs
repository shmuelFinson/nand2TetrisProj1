open System
open System.IO


//pop functions:

  //pop segment(local/argument/this/that) offset  - pop #1
  let pop_segment_local_argument_this_that_offset(register:string, offset:string) =  
      let offset1 = offset
      let reg = match register with
      |"local" ->  "LCL"
      |"argument" ->  "ARG"
      |"this" ->  "THIS"
      |"that" ->  "THAT"

      let newLine = "\n"
      let comment = "//pop " + reg +  offset1 + newLine 
      let atOffset = "@"+ offset1 + "\n" 
      let atRegister = "@" + reg + "\n"
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","@SP\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","M=M-1\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","D=A\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atRegister)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=M+D
@R13
M=D
@SP
A=M
D=M
@R13
A=M
M=D\n")

let pop_segement_pointer_temp(register:string, offset:string) = 
    let comment = "//pop " + register + offset
    let reg = match register with
           |"pointer" ->  "3"
           |"temp" ->  "5"
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment + "\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","@" + offset)
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","D=A\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","@" + reg + "\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=A+D
@R13
M=D
@SP
A=M
D=M
@R13
A=M
M=D\n")









  //pop static offset - pop #3
  let pop_static_offset(currentFileName:string, offset:string) = 
    let comment = "//pop static " + offset
    let atFileName = "@StaticTest.vm." + offset + "\n"
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
A=M
D=M\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atFileName)
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","M=D\n")



   

  //pop constant offset - pop #4
  let pop_constant_offset(offset:string) = 
      let offset1 = offset
      let newLine = "\n"
      let comment = "//pop constant " + offset1 + newLine
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1\n")



  // push functions:

  //push segment(local/argument/this/that) offset  - push #1
  let push_Lcl_Arg_This_That_Offset (register:string , offset:string) = 
      let sourceReg = register
      let offset1 = offset.ToString()
      let newLine = "\n"
      let reg = match register with
          |"local" ->  "LCL"
          |"argument" ->  "ARG"
          |"this" ->  "THIS"
          |"that" ->  "THAT"

      let comment = "//push " + reg + " " + offset1 + newLine
      let atReg = "@" + offset1
      let atSourceReg = "@" + sourceReg + newLine
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atReg)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"\n
D=A\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","@" + reg + "\n") //"@%s\n" register
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"A=M+D
D=M
@SP
A=M
M=D
@SP
M=M+1")

  //push (temp) offset  - push #2





let push_pointer_temp_offset(register:string,offset:string) = 
   let atOffset = "@" + offset
   let comment = "//push " + register + offset
   let reg = match register with
        |"pointer" ->  "3"
        |"temp" ->  "5"
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment + "\n")
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset + "\n")
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=A\n")
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","@" + reg + "\n")
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"A=A+D
D=M
@SP
A=M
M=D
@SP
M=M+1\n")









  //push static offset - push #3
  let push_static_offset(value:string) =
      let offset = value
      let newLine = "\n"
      let comment = "// push static " + offset + newLine
      let atFileName = "@StaticTest.vm." + offset + "\n"
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atFileName)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=M
@SP
A=M
M=D
@SP
M=M+1\n")


  
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
                  |"temp" -> push_pointer_temp_offset(sourceReg, offset)
                  |"pointer" -> push_pointer_temp_offset(sourceReg, offset)
                

     


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
                  |"temp"-> pop_segement_pointer_temp(sourceReg,offset)
                  |"pointer" ->pop_segement_pointer_temp(sourceReg,offset)
                  | "static" -> pop_static_offset(sourceReg,offset)
                  |_ ->  printf "Unknown\n"

  //translate an add command into HACK
  let add_2_hack (lineOfCode:string) = 
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
M=M+1\n")

  let neg_2_hack(lineOfCode:string) = 
       File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"\n//neg
@SP
A=M-1
D=M
M=-D\n")

  let eq_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//eq\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
A=M
D=D-A
@L1
D;JEQ
@L2
D=0;JEQ
(L1)
D=-1
(L2)
@SP
A=M
M=D
@SP
M=M+1\n")


let gt_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//gt\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
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
@L1
D;JGT
@L2
D=0;JEQ
(L1)
D=-1
(L2)
@SP
A=M
M=D
@SP
M=M+1\n")

let lt_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//lt\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
A=M
D=D-A
@L1
D;JGT
@L2
D=0;JEQ
(L1)
D=-1
(L2)
@SP
A=M
M=D
@SP
M=M+1\n")


let and_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//and\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
A=M
D=D&A
@SP
A=M
M=D
@SP
M=M+1\n")

let or_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//or\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
@SP
A=M
D=M
@SP
M=M-1
@SP
A=M
A=M
D=D|A
@SP
A=M
M=D
@SP
M=M+1\n")

let not_2_hack(lineOfCode:string) = 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n//not\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
A=M-1
D=M
M=!D\n")






[<EntryPoint>]
let main argv =
   
 
              
       
    //read the file into a string
    let lines = File.ReadAllLines(@"C:\Users\Shmuel Finson\Desktop\עקרונות שפות תכנה\nand2tetris\projects\07\StackArithmetic\StackTest\StackTest.vm") //C:\Users\Shmuel Finson\Desktop\עקרונות שפות תכנה\nand2tetris\projects\07\MemoryAccess\BasicTest\BasicTest.vm
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
             |"neg" -> neg_2_hack command
             |"eq" -> eq_2_hack command
             |"lt" -> lt_2_hack command
             |"gt" -> gt_2_hack command
             |"and" -> and_2_hack command
             |"or" -> or_2_hack command
             |"not" -> not_2_hack command
             |_ ->  printf "%s" firstWord.[0]
        
    0 // return an integer exit code

        

       





  

