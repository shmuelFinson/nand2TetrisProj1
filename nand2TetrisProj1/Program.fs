open System
open System.IO


//pop functions:

  //pop segment(local/argument/this/that) offset  - pop #1
  let pop_segment_local_argument_this_that_offset(register:string, offset:string) =  
      let offset1 = offset 
      let Destregister = register 
      let newLine = "\n"
      let comment = "//pop " + Destregister +  offset1 + newLine 
      let atOffset = "@"+ offset1 + "\n" 
      let atRegister = "@" + Destregister + "\n"
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

  //pop segment(temp) offset - pop #2
  let pop_segment_temp_offset(register:string, offset:string) = 
      let destReg = register
      let offset1 = offset
      let newLine = "\n"
      let atOffset = "@" + offset1 + newLine
      let offNum = offset|>int
      let offsetPlusFive = offNum + 5
      let atoffsetPlusFive = "@" + offsetPlusFive.ToString() + newLine
      let comment = "//pop " + destReg + " " + offset1 + newLine
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
M=M-1
D=M\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"D=A\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atoffsetPlusFive)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"M=D
@SP
M=M-1\n")

let pop_pointer0_offset(sourceReg, offset)=
    let register = sourceReg
    let offset0 = offset
    let target = "@3"
    let comment = "//pop" + sourceReg + offset0  // //push (pointer) offset\n
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
A=M-1
D=M\n")
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",target) 
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"M=D
 @SP
M=M-1\n")

let pop_pointer1_offset(sourceReg, offset)=
   let register = sourceReg
   let offset0 = offset
   let target = "@4"
   let newLine = "\n"
   let comment = "//pop" + sourceReg + offset0 + newLine // //push (pointer) offset\n
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
A=M-1
D=M\n")
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",target) 
   File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"M=D
@SP
M=M-1\n")



  //pop static offset - pop #3
  let pop_static_offset(currentFileName:string, offset:string) = 
    let newLine = "\n"
    let fileName = currentFileName.ToString()
    let offset1 = offset.ToString()
    let dot = 
    let comment = "//pop static " + offset1
    let filepointoffset = fileName + "." + offset1
    File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
    File.AppendAllLines("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
A=M-1\n"
    )
    File.AppendAllLines("C:\Users\Shmuel Finson\Desktop\experiment.asm", filepointoffset)
    File.AppendAllLines("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"@SP
A=M-1\n")
   

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
      let comment = "//push " + sourceReg + " " + offset1 + newLine
      let atReg = "@" + offset1
      let atSourceReg = "@" + sourceReg + newLine
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atReg)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\nD=A\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atSourceReg) //"@%s\n" register
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"A=M+D
D=M
@SP
A=M
M=D
@SP
M=M+1")

  //push (temp) offset  - push #2
  let push_temp_offest(register:string, offset:string) = 
      let sourceReg = register
      let offset1 = offset
      let offNum  = offset1 |>int
      let target = 5 + offNum
      let newLine = "\n"
      let comment = "//push " + sourceReg + offset1 + newLine // //push (pointer\temp) offset\n
      let atReg = "@" + sourceReg + newLine
      let atOffset = "@" + offset1 + newLine
      let attarget = "@" + target.ToString() + newLine
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atOffset)  //printf "@(3/5)\n"??
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","D=A")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",attarget)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,"A=A+D
D=M
@SP
A=M
M=D
@SP
M=M+1")

let push_pointer0_offset(register, offset) =
     let sourceReg = register
     let offset0 = offset
     let newLine = "\n"
     let target = "@3"
     let comment = "//push " + sourceReg + offset0 + newLine // //push (pointer) offset\n
     File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
     File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",target) 
     File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,
"D=M
 @SP
 A=M
 M=D
 @SP
 M=M+1")



  let push_pointer1_offset(register, offset) =
      let sourceReg = register
      let offset0 = offset
      let newLine = "\n"
      let target = "@4"
      let comment = "//push " + sourceReg + offset0 + newLine // //push (pointer) offset\n
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",target) 
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm"
,
"D=M
 @SP
 A=M
 M=D
 @SP
 M=M+1")



  //push static offset - push #3
  let push_static_offset(value:string) =
      let offset = value
      let newLine = "\n"
      let comment = "// push static " + offset + newLine
      let atFileName = "@C:\Users\Shmuel Finson\Desktop\עקרונות שפות תכנה\nand2tetris\projects\07\MemoryAccess\StaticTest\StaticTest.vm." + offset + "\n"
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm","\n")
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",comment)
      File.AppendAllText("C:\Users\Shmuel Finson\Desktop\experiment.asm",atFileName)
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
                  //| "static" -> push_static_offset(offset)
                  |"temp" -> push_temp_offest(sourceReg, offset)
                  |"pointer"
                  |_->
                    match offset with
                    |"0"->push_pointer0_offset(sourceReg, offset)
                    |"1"->push_pointer1_offset(sourceReg, offset)
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
                  |"temp"-> pop_segment_temp_offset(sourceReg,offset)
                  |"pointer"
                  |_->
                    match offset with
                    |"0"->pop_pointer0_offset(sourceReg, offset)
                    |"1"->pop_pointer1_offset(sourceReg, offset)
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
,"//neg
@SP
A=M-1
D=M
M=-D\n")

[<EntryPoint>]
let main argv =
   
 
              
       
    //read the file into a string
    let lines = File.ReadAllLines(@"C:\Users\Shmuel Finson\Desktop\עקרונות שפות תכנה\nand2tetris\projects\07\StackArithmetic\SimpleAdd\SimpleAdd.vm") //C:\Users\Shmuel Finson\Desktop\עקרונות שפות תכנה\nand2tetris\projects\07\MemoryAccess\BasicTest\BasicTest.vm
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
            // |"eq" -> eq_2_hack command
             |_ ->  printf "Unknown\n"
        
    0 // return an integer exit code

        

       





  

