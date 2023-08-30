# ThickClientUtils

A .NET Framework library to apply RegEx search/replace rules and/or log strings after being injected into a DLL/EXE

![](screenshots\Add%20Library.png)
![](screenshots\ILCode.png)

Rules: [rules.json](ThickClientUtils\rules.json)

Instructions:
- Build the library in Visual Studio (I used VS 2022 with .NET Framework 4.6.2)
- Copy `ThickClientUtils\bin\Debug` to the folder in which the thick-client resides
- Edit rules.json (in that target folder you just copied everything to) to add you find/replace rules
- Use Dnspy/DnspyEx to edit the method you want to inject this code into, you will have to add a reference to it. See one example above (screenshot)
- For Modifying Strings (which also logs):
    - Add the following C# code: `content = RuleManager.ApplyRules(content);`
    - or the following IL code (you will have to adapt the ldloc/stloc with wherever the variable is)
        - `ldloc.0`
        - `call	string ThickClientUtils.RuleManager::ApplyRules(string)`
        - `stloc.0`
    - another version
        - `ldarg.1`
        - `call	string [ThickClientUtils]ThickClientUtils.RuleManager::ApplyRules(string)`
        - `starg	xmlRequest (1)`
- For Logging:
  - Add the folloing C# code: `Logger.Log(content);`
  - or the following IL code (you will have to adapt the ldloc/stloc with wherever the variable is)
    - `ldloc.0`
    - `call	void ThickClientUtils.Logger::Log(string)`
  - Find the log file at `<directory you copied it to>/logs/<datetime>.log`