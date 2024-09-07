import pythonnet

pythonnet.load("coreclr")
# print(pythonnet.get_runtime_info())


import os
import clr

publishPath = os.path.join(os.getcwd(),
                           "..",
                           "CSharpLib",
                           "bin",
                           "Release",
                           "net6.0",
                           "publish",
                           "win-x64")
dllPath = os.path.join(publishPath, "CSharpIntoPython.dll")
clr.AddReference(dllPath)


# from namespace import class
from CSharpIntoPython import Class1

hello_world = Class1.HelloWorld
write_to_docx = Class1.WriteToDocx