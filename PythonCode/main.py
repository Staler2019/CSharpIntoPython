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