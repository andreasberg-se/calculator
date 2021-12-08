# calculator
A simple calculator, written in C#.

The project is tested in Mono.


First compile "UserInput.cs" as a module:

mcs -t:module UserInput.cs



Then include the module when compiling "Calculator.cs":

mcs -addmodule:UserInput.netmodule Calculator.cs
