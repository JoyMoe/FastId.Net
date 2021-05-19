# FastId.Net

Snowflake-like ID generating for .Net

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/JoyMoe/FastId.Net/build)
[![Codecov](https://img.shields.io/codecov/c/github/JoyMoe/FastId.Net.svg)](https://codecov.io/gh/JoyMoe/FastId.Net)
[![license](https://img.shields.io/github/license/JoyMoe/FastId.Net.svg)](https://github.com/JoyMoe/FastId.Net/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/FastId-Net.svg)](https://www.nuget.org/packages/FastId-Net)
[![NuGet](https://img.shields.io/nuget/vpre/FastId-Net.svg)](https://www.nuget.org/packages/FastId-Net/absoluteLatest)
![netstandard2.0](https://img.shields.io/badge/.Net-netstandard2.0-brightgreen.svg)

## Example

```csharp
var s = (new byte[] { 116, 32, 8, 99, 100, 232, 4, 7 }).ToBase62();

var b = "T208OsJe107".FromBase62();
```

## License

The MIT License

More info see [LICENSE](LICENSE)
