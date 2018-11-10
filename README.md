littleClient
============

Small example working through using CoreRT from F#.

### Building

macOS - Mach-O 64-bit executable x86_64
```
dotnet publish -r osx-x64 -c release
```

Linux
```
dotnet publish -r linux-x64 -c release
```

### Features
* ACTUALLY WORKS!
* HTTP client and things like crypto libraries working
* Using `mono.options` as a .NET Standard compatible argument parser
* Baseline binary is going to be 26 MB - goes up from there with more dependencies

### Limitations
* Can't use `printfn` or `sprintf` at this time - this excludes most F#
  libraries
* Cross platform builds aren't possible - you have to build on the target platform
* On Windows, you'll need Visual Studio so you have the linker
